using System;
using System.Collections.Concurrent;
using System.IO;

using S2Library.Connection;
using S2Library.Protocol;

using System.Threading.Tasks;

namespace S2Lobby
{
    public class Program
    {
        private static async Task<ConsoleKey> GetConsoleKeyEvent()
        {
            try
            {
                return await Task.Run(() => Console.ReadKey(true).Key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Main(string[] args)
        {
            new Program().Run().Wait();
            ((IDisposable)Logger.Instance).Dispose();
            GC.Collect();
        }

        private readonly ConnectionManager _lobbyConnectionManager = new ConnectionManager();
        private readonly ConnectionManager _chatConnectionManager = new ConnectionManager();

        private readonly ConcurrentDictionary<uint, Connection> _incomingLobbyConnections = new ConcurrentDictionary<uint, Connection>();
        private readonly ConcurrentDictionary<uint, Connection> _incomingChatConnections = new ConcurrentDictionary<uint, Connection>();

        private readonly ConcurrentDictionary<uint, NetworkProcessor> _incomingLobbyProcessors = new ConcurrentDictionary<uint, NetworkProcessor>();
        private readonly ConcurrentDictionary<uint, ConcurrentQueue<byte[]>> _outgoingLobbyQueues = new ConcurrentDictionary<uint, ConcurrentQueue<byte[]>>();

        private readonly ConcurrentDictionary<uint, NetworkProcessor> _incomingChatProcessors = new ConcurrentDictionary<uint, NetworkProcessor>();
        private readonly ConcurrentDictionary<uint, ConcurrentQueue<byte[]>> _outgoingChatQueues = new ConcurrentDictionary<uint, ConcurrentQueue<byte[]>>();

        public static readonly Accounts Accounts = new Accounts();
        public static readonly Servers Servers = new Servers();
        public static readonly Channels Channels = new Channels();

        private async Task Run()
        {
            Accounts.Init(this);
            Servers.Init(this);
            Channels.Init(this);

            _lobbyConnectionManager.Connected += LobbyConnectionManagerOnConnected;
            _lobbyConnectionManager.ConnectFailed += LobbyConnectionManagerOnConnectFailed;

            _chatConnectionManager.Connected += ChatConnectionManagerOnConnected;
            _chatConnectionManager.ConnectFailed += ChatConnectionManagerOnConnectFailed;

            _lobbyConnectionManager.InitServer(null, Config.GetInt("lobby/port"));
            _chatConnectionManager.InitServer(null, Config.GetInt("chat/port"));

            Logger.Log($"[Lobby server running]");
            Logger.Log($" - press S to quit -");
            while(await GetConsoleKeyEvent() != ConsoleKey.S) {};
            Logger.Log($"[Lobby server shutting down]");

            _chatConnectionManager.Shutdown();
            _lobbyConnectionManager.Shutdown();
        }


        private void LobbyConnectionManagerOnConnected(ConnectionEventArgs args)
        {
            Logger.LogDebug($"GAME -> LOBBY Connected: {args.Conn.Id}");

            if (args.Conn.IsIncomingConnection)
            {
                if (!_incomingLobbyProcessors.TryAdd(args.Conn.Id, new LobbyProcessor(this, args.Conn.Id)))
                {
                    Logger.Log($" Can't add to incoming lobby processors: {args.Conn.Id}");
                }

                if (!_outgoingLobbyQueues.TryAdd(args.Conn.Id, new ConcurrentQueue<byte[]>()))
                {
                    Logger.Log($" Can't add to outgoing lobby queues: {args.Conn.Id}");
                }

                if (!_incomingLobbyConnections.TryAdd(args.Conn.Id, args.Conn))
                {
                    Logger.Log($" Can't add to incoming lobby connections: {args.Conn.Id}");
                }
            }
            args.Conn.ConnectionLost += LobbyConnOnConnectionLost;
            args.Conn.Disconnected += LobbyConnOnDisconnected;
            args.Conn.Received += LobbyConnOnReceived;
            args.Conn.ThreadTick += LobbyConnOnThreadTick;
        }

        private void ChatConnectionManagerOnConnected(ConnectionEventArgs args)
        {
            Logger.LogDebug($"GAME -> CHAT Connected: {args.Conn.Id}");

            if (args.Conn.IsIncomingConnection)
            {
                if (!_incomingChatProcessors.TryAdd(args.Conn.Id, new ChatProcessor(this, args.Conn.Id)))
                {
                    Logger.Log($" Can't add to incoming chat processors: {args.Conn.Id}");
                }

                if (!_outgoingChatQueues.TryAdd(args.Conn.Id, new ConcurrentQueue<byte[]>()))
                {
                    Logger.Log($" Can't add to outgoing chat queues: {args.Conn.Id}");
                }

                if (!_incomingChatConnections.TryAdd(args.Conn.Id, args.Conn))
                {
                    Logger.Log($" Can't add to incoming chat connections: {args.Conn.Id}");
                }
            }
            args.Conn.ConnectionLost += ChatConnOnConnectionLost;
            args.Conn.Disconnected += ChatConnOnDisconnected;
            args.Conn.Received += ChatConnOnReceived;
            args.Conn.ThreadTick += ChatConnOnThreadTick;
        }

        private void LobbyConnectionManagerOnConnectFailed(ConnectionResultArgs args)
        {
            Logger.Log($"LOBBY Connection failed: {args.Result}: {args.Conn.Id}");
        }

        private void ChatConnectionManagerOnConnectFailed(ConnectionResultArgs args)
        {
            Logger.Log($"CHAT Connection failed: {args.Result}: {args.Conn.Id}");
        }

        private void LobbyConnOnDisconnected(ConnectionEventArgs args)
        {
            if (_incomingLobbyConnections.ContainsKey(args.Conn.Id))
            {
                Logger.LogDebug($"GAME -> LOBBY Disconnected: {args.Conn.Id}");

                NetworkProcessor incomingLobbyProcessor;
                if (!_incomingLobbyProcessors.TryRemove(args.Conn.Id, out incomingLobbyProcessor))
                {
                    Logger.Log($" Can't remove from incoming lobby processors: {args.Conn.Id}");
                }
                incomingLobbyProcessor.Close();

                ConcurrentQueue<byte[]> outgoingLobbyQueue;
                if (!_outgoingLobbyQueues.TryRemove(args.Conn.Id, out outgoingLobbyQueue))
                {
                    Logger.Log($" Can't remove from outgoing lobby queues: {args.Conn.Id}");
                }

                Connection incomingLobbyConnection;
                if (!_incomingLobbyConnections.TryRemove(args.Conn.Id, out incomingLobbyConnection))
                {
                    Logger.Log($" Can't remove from incoming lobby connections: {args.Conn.Id}");
                }
            }
        }

        private void ChatConnOnDisconnected(ConnectionEventArgs args)
        {
            if (_incomingChatConnections.ContainsKey(args.Conn.Id))
            {
                Logger.LogDebug($"GAME -> CHAT Disconnected: {args.Conn.Id}");

                NetworkProcessor incomingChatProcessor;
                if (!_incomingChatProcessors.TryRemove(args.Conn.Id, out incomingChatProcessor))
                {
                    Logger.Log($" Can't remove from incoming chat processors: {args.Conn.Id}");
                }
                incomingChatProcessor.Close();

                ConcurrentQueue<byte[]> outgoingChatQueue;
                if (!_outgoingChatQueues.TryRemove(args.Conn.Id, out outgoingChatQueue))
                {
                    Logger.Log($" Can't remove from outoing chat queues: {args.Conn.Id}");
                }

                Connection incomingChatConnection;
                if (!_incomingChatConnections.TryRemove(args.Conn.Id, out incomingChatConnection))
                {
                    Logger.Log($" Can't remove from incoming chat connections: {args.Conn.Id}");
                }
            }
        }

        private void LobbyConnOnConnectionLost(ConnectionResultArgs args)
        {
            if (_incomingLobbyConnections.ContainsKey(args.Conn.Id))
            {
                Logger.LogDebug($"GAME -> LOBBY Connection lost:{args.Result}: {args.Conn.Id}");

                NetworkProcessor incomingLobbyProcessor;
                if (!_incomingLobbyProcessors.TryRemove(args.Conn.Id, out incomingLobbyProcessor))
                {
                    Logger.Log($" Can't remove from incoming lobby processors: {args.Conn.Id}");
                }
                incomingLobbyProcessor.Close();

                ConcurrentQueue<byte[]> outgoingLobbyQueue;
                if (!_outgoingLobbyQueues.TryRemove(args.Conn.Id, out outgoingLobbyQueue))
                {
                    Logger.Log($" Can't remove from outgoing lobby queues: {args.Conn.Id}");
                }

                Connection incomingLobbyConnection;
                if (!_incomingLobbyConnections.TryRemove(args.Conn.Id, out incomingLobbyConnection))
                {
                    Logger.Log($" Can't remove from incoming lobby connections: {args.Conn.Id}");
                }
            }
        }

        private void ChatConnOnConnectionLost(ConnectionResultArgs args)
        {
            if (_incomingChatConnections.ContainsKey(args.Conn.Id))
            {
                Logger.LogDebug($"GAME -> CHAT Connection lost:{args.Result}: {args.Conn.Id}");

                NetworkProcessor incomingChatProcessor;
                if (!_incomingChatProcessors.TryRemove(args.Conn.Id, out incomingChatProcessor))
                {
                    Logger.Log($" Can't remove from incoming chat processors: {args.Conn.Id}");
                }
                incomingChatProcessor.Close();

                ConcurrentQueue<byte[]> outgoingChatQueue;
                if (!_outgoingChatQueues.TryRemove(args.Conn.Id, out outgoingChatQueue))
                {
                    Logger.Log($" Can't remove from outgoing chat queues: {args.Conn.Id}");
                }

                Connection incomingChatConnection;
                if (!_incomingChatConnections.TryRemove(args.Conn.Id, out incomingChatConnection))
                {
                    Logger.Log($" Can't remove from incoming chat connections: {args.Conn.Id}");
                }
            }
        }

        private void LobbyConnOnReceived(ConnectionReceiveArgs args)
        {
            NetworkProcessor incomingLobbyProcessor;
            if (_incomingLobbyProcessors.TryGetValue(args.Conn.Id, out incomingLobbyProcessor))
            {
                Logger.LogDebug($"GAME -> LOBBY: {args.Conn.Id}: {Serializer.DumpBytes(args.Data)}");

                try
                {
                    incomingLobbyProcessor.Receive(args.Data);
                }
                catch (Exception e)
                {
                    Logger.Log($"EXCEPTION {e} while handling incoming lobby stream");
                    args.Conn.Disconnect();
                }
            }
            else
            {
                Logger.Log($"LOBBY Unknown receive connection: {args.Conn.Id}");
            }
        }

        private void ChatConnOnReceived(ConnectionReceiveArgs args)
        {
            NetworkProcessor incomingChatProcessor;
            if (_incomingChatProcessors.TryGetValue(args.Conn.Id, out incomingChatProcessor))
            {
                Logger.LogDebug($"GAME -> CHAT: {args.Conn.Id}: {Serializer.DumpBytes(args.Data)}");

                try
                {
                    incomingChatProcessor.Receive(args.Data);
                }
                catch (Exception e)
                {
                    Logger.Log($"EXCEPTION {e} while handling incoming chat stream");
                    args.Conn.Disconnect();
                }
            }
            else
            {
                Logger.Log($"CHAT Unknown receive connection: {args.Conn.Id}");
            }
        }

        private void LobbyConnOnThreadTick(ConnectionEventArgs args)
        {
            NetworkProcessor incomingLobbyProcessor;

            if (!_incomingLobbyProcessors.TryGetValue(args.Conn.Id, out incomingLobbyProcessor))
            {
                Logger.LogDebug($"LOBBY Unknown incoming connection: {args.Conn.Id}");
                return;
            }

            ConcurrentQueue<byte[]> outgoingLobbyQueue;
            if (_outgoingLobbyQueues.TryGetValue(args.Conn.Id, out outgoingLobbyQueue))
            {
                incomingLobbyProcessor.Process(outgoingLobbyQueue);

                byte[] data;
                while (outgoingLobbyQueue.TryDequeue(out data))
                {
                    Logger.LogDebug($"LOBBY -> GAME: {args.Conn.Id}: {Serializer.DumpBytes(data)}");
                    args.Conn.Send(data);
                }
            }
            else
            {
                Logger.Log($"LOBBY Unknown outgoing connection: {args.Conn.Id}");
            }
        }

        private void ChatConnOnThreadTick(ConnectionEventArgs args)
        {
            NetworkProcessor incomingChatProcessor;

            if (!_incomingChatProcessors.TryGetValue(args.Conn.Id, out incomingChatProcessor))
            {
                Logger.LogDebug($"CHAT Unknown incoming connection: {args.Conn.Id}");
                return;
            }

            ConcurrentQueue<byte[]> outgoingChatQueue;
            if (_outgoingChatQueues.TryGetValue(args.Conn.Id, out outgoingChatQueue))
            {
                incomingChatProcessor.Process(outgoingChatQueue);

                byte[] data;
                while (outgoingChatQueue.TryDequeue(out data))
                {
                    Logger.LogDebug($"CHAT -> GAME: {args.Conn.Id}: {Serializer.DumpBytes(data)}");
                    args.Conn.Send(data);
                }
            }
            else
            {
                Logger.Log($"CHAT Unknown outgoing connection: {args.Conn.Id}");
            }
        }

        public LobbyProcessor GetLobbyProcessor(uint connId)
        {
            NetworkProcessor incomingLobbyProcessor;
            if (_incomingLobbyProcessors.TryGetValue(connId, out incomingLobbyProcessor))
            {
                return incomingLobbyProcessor as LobbyProcessor;
            }

            return null;
        }

        public ChatProcessor GetChatProcessor(uint connId)
        {
            NetworkProcessor incomingChatProcessor;
            if (_incomingChatProcessors.TryGetValue(connId, out incomingChatProcessor))
            {
                return incomingChatProcessor as ChatProcessor;
            }

            return null;
        }
    }
}
