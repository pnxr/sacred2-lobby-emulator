using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace S2Lobby
{
    public class Servers
    {
        public static uint IdCounter = 1;
        private static readonly object _lock = new object();

        private readonly ConcurrentDictionary<uint, Server> _servers = new ConcurrentDictionary<uint, Server>();

        private Program _program;

        public void Init(Program program)
        {
            _program = program;
            Logger.Log($"[Server list ready]");
        }

        private static uint GetId()
        {
            lock (_lock)
            {
                return ++IdCounter;
            }
        }

        public uint Register(string name)
        {
            Server server = new Server()
            {
                Id = GetId(),
                Name = name,
            };

            if (!_servers.TryAdd(server.Id, server))
            {
                Logger.Log($"Can't register server {name}");
                return 0;
            }

            return server.Id;
        }

        public Server Get(uint id)
        {
            Server server;
            if (_servers.TryGetValue(id, out server))
            {
                return server;
            }

            return null;
        }

        public void Remove(uint id)
        {
            if (id == 0)
            {
                return;
            }

            Server server;
            _servers.TryRemove(id, out server);
        }

        public List<Server> GetServers()
        {
            KeyValuePair<uint, Server>[] servers = _servers.ToArray();
            return servers.Select(server => server.Value).ToList();
        }
    }

    public class Server
    {
        public uint Id;
        public string Name;
        public uint ConnectionId;
        public uint OwnerId;
        public string Description;
        public string Ip;
        public uint Port;
        public byte Type;
        public byte SubType;
        public ushort MaxPlayers;
        public uint RoomId;
        public byte Level;
        public byte GameMode;
        public bool Hardcore;
        public bool Running;
        public bool LockedConfig;
        public byte[] Data;
        public bool NeedsPassword;
        public string Password;

        public ConcurrentDictionary<uint, uint> Players = new ConcurrentDictionary<uint, uint>();
    }
}
