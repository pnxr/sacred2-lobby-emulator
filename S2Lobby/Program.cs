using System;
using System.Collections.Concurrent;
using System.IO;
using S2Library.Connection;
using S2Library.Protocol;

namespace S2Lobby
{
    public class Program
    {
        private static void Main(string[] args)
        {
            new Program().Run();
        }

        private const uint LobbyPort = 6800;
        public const uint ChatPort = 6801;

        public string Ip { get; private set; } = "127.0.0.1";

        private readonly ConnectionManager _lobbyConnectionManager = new ConnectionManager();
        private readonly ConnectionManager _chatConnectionManager = new ConnectionManager();

        private readonly ConcurrentDictionary<uint, Connection> _incomingLobbyConnections = new ConcurrentDictionary<uint, Connection>();
        private readonly ConcurrentDictionary<uint, Connection> _incomingChatConnections = new ConcurrentDictionary<uint, Connection>();

        private readonly ConcurrentDictionary<uint, NetworkProcessor> _incomingLobbyProcessors = new ConcurrentDictionary<uint, NetworkProcessor>();
        private readonly ConcurrentDictionary<uint, ConcurrentQueue<byte[]>> _outgoingLobbyQueues = new ConcurrentDictionary<uint, ConcurrentQueue<byte[]>>();

        private readonly ConcurrentDictionary<uint, NetworkProcessor> _incomingChatProcessors = new ConcurrentDictionary<uint, NetworkProcessor>();
        private readonly ConcurrentDictionary<uint, ConcurrentQueue<byte[]>> _outgoingChatQueues = new ConcurrentDictionary<uint, ConcurrentQueue<byte[]>>();

        private bool _running = true;
        private StreamWriter _fileStream;
        private readonly object _sync = new object();

        public static readonly Accounts Accounts = new Accounts();
        public static readonly Servers Servers = new Servers();

        private void Run()
        {
            if (File.Exists("ip.cfg"))
            {
                string[] lines = File.ReadAllLines("ip.cfg");
                if (lines.Length > 0)
                {
                    Ip = lines[0];
                }
            }

            lock (_sync)
            {
#if DEBUG
                _fileStream = File.CreateText("lobby_net_dump.txt");
#else
                _fileStream = File.CreateText("lobby_log.txt");
#endif
            }

            Log($"[Log system ready]");

            Accounts.Init(this);
            Servers.Init(this);

            _lobbyConnectionManager.Connected += LobbyConnectionManagerOnConnected;
            _lobbyConnectionManager.ConnectFailed += LobbyConnectionManagerOnConnectFailed;

            _chatConnectionManager.Connected += ChatConnectionManagerOnConnected;
            _chatConnectionManager.ConnectFailed += ChatConnectionManagerOnConnectFailed;

            _lobbyConnectionManager.InitServer(null, LobbyPort);
            _chatConnectionManager.InitServer(null, ChatPort);

            Log($"[Lobby server running]");
            Log($" - press S to quit -");

            while (_running)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.S)
                {
                    _running = false;
                }
            }

            Log($"[Lobby server shutting down]");

            _chatConnectionManager.Shutdown();
            _lobbyConnectionManager.Shutdown();
            lock (_sync)
            {
                _fileStream.Close();
                _fileStream = null;
            }
        }

        public void LogDebug(string text)
        {
#if DEBUG
            Log(text);
#endif
        }

        public void Log(string text)
        {
            lock (_sync)
            {
                _fileStream?.WriteLine(text);
                Console.WriteLine(text);
            }
        }

        private void LobbyConnectionManagerOnConnected(ConnectionEventArgs args)
        {
            LogDebug($"GAME -> LOBBY Connected: {args.Conn.Id}");

            if (args.Conn.IsIncomingConnection)
            {
                if (!_incomingLobbyProcessors.TryAdd(args.Conn.Id, new LobbyProcessor(this, args.Conn.Id)))
                {
                    Log($" Can't add to incoming lobby processors: {args.Conn.Id}");
                }

                if (!_outgoingLobbyQueues.TryAdd(args.Conn.Id, new ConcurrentQueue<byte[]>()))
                {
                    Log($" Can't add to outgoing lobby queues: {args.Conn.Id}");
                }

                if (!_incomingLobbyConnections.TryAdd(args.Conn.Id, args.Conn))
                {
                    Log($" Can't add to incoming lobby connections: {args.Conn.Id}");
                }
            }
            args.Conn.ConnectionLost += LobbyConnOnConnectionLost;
            args.Conn.Disconnected += LobbyConnOnDisconnected;
            args.Conn.Received += LobbyConnOnReceived;
            args.Conn.ThreadTick += LobbyConnOnThreadTick;
        }

        private void ChatConnectionManagerOnConnected(ConnectionEventArgs args)
        {
            LogDebug($"GAME -> CHAT Connected: {args.Conn.Id}");

            if (args.Conn.IsIncomingConnection)
            {
                if (!_incomingChatProcessors.TryAdd(args.Conn.Id, new ChatProcessor(this, args.Conn.Id)))
                {
                    Log($" Can't add to incoming chat processors: {args.Conn.Id}");
                }

                if (!_outgoingChatQueues.TryAdd(args.Conn.Id, new ConcurrentQueue<byte[]>()))
                {
                    Log($" Can't add to outgoing chat queues: {args.Conn.Id}");
                }

                if (!_incomingChatConnections.TryAdd(args.Conn.Id, args.Conn))
                {
                    Log($" Can't add to incoming chat connections: {args.Conn.Id}");
                }
            }
            args.Conn.ConnectionLost += ChatConnOnConnectionLost;
            args.Conn.Disconnected += ChatConnOnDisconnected;
            args.Conn.Received += ChatConnOnReceived;
            args.Conn.ThreadTick += ChatConnOnThreadTick;
        }

        private void LobbyConnectionManagerOnConnectFailed(ConnectionResultArgs args)
        {
            Log($"LOBBY Connection failed: {args.Result}: {args.Conn.Id}");
        }

        private void ChatConnectionManagerOnConnectFailed(ConnectionResultArgs args)
        {
            Log($"CHAT Connection failed: {args.Result}: {args.Conn.Id}");
        }

        private void LobbyConnOnDisconnected(ConnectionEventArgs args)
        {
            if (_incomingLobbyConnections.ContainsKey(args.Conn.Id))
            {
                LogDebug($"GAME -> LOBBY Disconnected: {args.Conn.Id}");

                NetworkProcessor incomingLobbyProcessor;
                if (!_incomingLobbyProcessors.TryRemove(args.Conn.Id, out incomingLobbyProcessor))
                {
                    incomingLobbyProcessor.Close();
                    Log($" Can't remove from incoming lobby processors: {args.Conn.Id}");
                }

                ConcurrentQueue<byte[]> outgoingLobbyQueue;
                if (!_outgoingLobbyQueues.TryRemove(args.Conn.Id, out outgoingLobbyQueue))
                {
                    Log($" Can't remove from outgoing lobby queues: {args.Conn.Id}");
                }

                Connection incomingLobbyConnection;
                if (!_incomingLobbyConnections.TryRemove(args.Conn.Id, out incomingLobbyConnection))
                {
                    Log($" Can't remove from incoming lobby connections: {args.Conn.Id}");
                }
            }
        }

        private void ChatConnOnDisconnected(ConnectionEventArgs args)
        {
            if (_incomingChatConnections.ContainsKey(args.Conn.Id))
            {
                LogDebug($"GAME -> CHAT Disconnected: {args.Conn.Id}");

                NetworkProcessor incomingChatProcessor;
                if (!_incomingChatProcessors.TryRemove(args.Conn.Id, out incomingChatProcessor))
                {
                    incomingChatProcessor.Close();
                    Log($" Can't remove from incoming chat processors: {args.Conn.Id}");
                }

                ConcurrentQueue<byte[]> outgoingChatQueue;
                if (!_outgoingChatQueues.TryRemove(args.Conn.Id, out outgoingChatQueue))
                {
                    Log($" Can't remove from outoing chat queues: {args.Conn.Id}");
                }

                Connection incomingChatConnection;
                if (!_incomingChatConnections.TryRemove(args.Conn.Id, out incomingChatConnection))
                {
                    Log($" Can't remove from incoming chat connections: {args.Conn.Id}");
                }
            }
        }

        private void LobbyConnOnConnectionLost(ConnectionResultArgs args)
        {
            if (_incomingLobbyConnections.ContainsKey(args.Conn.Id))
            {
                LogDebug($"GAME -> LOBBY Connection lost:{args.Result}: {args.Conn.Id}");

                NetworkProcessor incomingLobbyProcessor;
                if (!_incomingLobbyProcessors.TryRemove(args.Conn.Id, out incomingLobbyProcessor))
                {
                    incomingLobbyProcessor.Close();
                    Log($" Can't remove from incoming lobby processors: {args.Conn.Id}");
                }

                ConcurrentQueue<byte[]> outgoingLobbyQueue;
                if (!_outgoingLobbyQueues.TryRemove(args.Conn.Id, out outgoingLobbyQueue))
                {
                    Log($" Can't remove from outgoing lobby queues: {args.Conn.Id}");
                }

                Connection incomingLobbyConnection;
                if (!_incomingLobbyConnections.TryRemove(args.Conn.Id, out incomingLobbyConnection))
                {
                    Log($" Can't remove from incoming lobby connections: {args.Conn.Id}");
                }
            }
        }

        private void ChatConnOnConnectionLost(ConnectionResultArgs args)
        {
            if (_incomingChatConnections.ContainsKey(args.Conn.Id))
            {
                LogDebug($"GAME -> CHAT Connection lost:{args.Result}: {args.Conn.Id}");

                NetworkProcessor incomingChatProcessor;
                if (!_incomingChatProcessors.TryRemove(args.Conn.Id, out incomingChatProcessor))
                {
                    incomingChatProcessor.Close();
                    Log($" Can't remove from incoming chat processors: {args.Conn.Id}");
                }

                ConcurrentQueue<byte[]> outgoingChatQueue;
                if (!_outgoingChatQueues.TryRemove(args.Conn.Id, out outgoingChatQueue))
                {
                    Log($" Can't remove from outgoing chat queues: {args.Conn.Id}");
                }

                Connection incomingChatConnection;
                if (!_incomingChatConnections.TryRemove(args.Conn.Id, out incomingChatConnection))
                {
                    Log($" Can't remove from incoming chat connections: {args.Conn.Id}");
                }
            }
        }

        private void LobbyConnOnReceived(ConnectionReceiveArgs args)
        {
            NetworkProcessor incomingLobbyProcessor;
            if (_incomingLobbyProcessors.TryGetValue(args.Conn.Id, out incomingLobbyProcessor))
            {
                LogDebug($"GAME -> LOBBY: {args.Conn.Id}: {Serializer.DumpBytes(args.Data)}");

                try
                {
                    incomingLobbyProcessor.Receive(args.Data);
                }
                catch (Exception e)
                {
                    Log($"EXCEPTION {e} while handling incoming lobby stream");
                    args.Conn.Disconnect();
                }
            }
            else
            {
                Log($"LOBBY Unknown receive connection: {args.Conn.Id}");
            }
        }

        private void ChatConnOnReceived(ConnectionReceiveArgs args)
        {
            NetworkProcessor incomingChatProcessor;
            if (_incomingChatProcessors.TryGetValue(args.Conn.Id, out incomingChatProcessor))
            {
                LogDebug($"GAME -> CHAT: {args.Conn.Id}: {Serializer.DumpBytes(args.Data)}");

                try
                {
                    incomingChatProcessor.Receive(args.Data);
                }
                catch (Exception e)
                {
                    Log($"EXCEPTION {e} while handling incoming chat stream");
                    args.Conn.Disconnect();
                }
            }
            else
            {
                Log($"CHAT Unknown receive connection: {args.Conn.Id}");
            }
        }

        private void LobbyConnOnThreadTick(ConnectionEventArgs args)
        {
            NetworkProcessor incomingLobbyProcessor;

            if (!_incomingLobbyProcessors.TryGetValue(args.Conn.Id, out incomingLobbyProcessor))
            {
                LogDebug($"LOBBY Unknown incoming connection: {args.Conn.Id}");
                return;
            }

            ConcurrentQueue<byte[]> outgoingLobbyQueue;
            if (_outgoingLobbyQueues.TryGetValue(args.Conn.Id, out outgoingLobbyQueue))
            {
                incomingLobbyProcessor.Process(outgoingLobbyQueue);

                byte[] data;
                while (outgoingLobbyQueue.TryDequeue(out data))
                {
                    LogDebug($"LOBBY -> GAME: {args.Conn.Id}: {Serializer.DumpBytes(data)}");
                    args.Conn.Send(data);
                }
            }
            else
            {
                Log($"LOBBY Unknown outgoing connection: {args.Conn.Id}");
            }
        }

        private void ChatConnOnThreadTick(ConnectionEventArgs args)
        {
            NetworkProcessor incomingChatProcessor;

            if (!_incomingChatProcessors.TryGetValue(args.Conn.Id, out incomingChatProcessor))
            {
                LogDebug($"CHAT Unknown incoming connection: {args.Conn.Id}");
                return;
            }

            ConcurrentQueue<byte[]> outgoingChatQueue;
            if (_outgoingChatQueues.TryGetValue(args.Conn.Id, out outgoingChatQueue))
            {
                incomingChatProcessor.Process(outgoingChatQueue);

                byte[] data;
                while (outgoingChatQueue.TryDequeue(out data))
                {
                    LogDebug($"CHAT -> GAME: {args.Conn.Id}: {Serializer.DumpBytes(data)}");
                    args.Conn.Send(data);
                }
            }
            else
            {
                Log($"CHAT Unknown outgoing connection: {args.Conn.Id}");
            }
        }

        public NetworkProcessor GetLobbyProcessor(uint connId)
        {
            NetworkProcessor incomingLobbyProcessor;
            if (_incomingLobbyProcessors.TryGetValue(connId, out incomingLobbyProcessor))
            {
                return incomingLobbyProcessor;
            }

            return null;
        }

        public NetworkProcessor GetChatProcessor(uint connId)
        {
            NetworkProcessor incomingChatProcessor;
            if (_incomingChatProcessors.TryGetValue(connId, out incomingChatProcessor))
            {
                return incomingChatProcessor;
            }

            return null;
        }
    }
}
