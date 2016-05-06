using System;
using System.Collections.Generic;
using System.Linq;

namespace Belot.WebApi.ConnectionManagers
{
    public class GameConnectionManager
    {
        public GameConnectionManager()
        {
            Connections = new Dictionary<int, ISet<GameConnection>>();
        }

        // <gameId, <connectionsId>>
        public IDictionary<int, ISet<GameConnection>> Connections { get; private set; }

        public void AddConnection(int gameId, string connectionId, string userName)
        {
            lock (Connections)
            {
                ISet<GameConnection> cnns;
                if (!Connections.TryGetValue(gameId, out cnns))
                {
                    cnns = new HashSet<GameConnection>();
                    Connections.Add(gameId, cnns);
                }

                lock (cnns)
                {
                    cnns.Add(new GameConnection(connectionId, userName));
                }
            }
        }

        public int RemoveConnection(string connectionId)
        {
            lock (Connections)
            {
                foreach (int gameId in Connections.Keys)
                {
                    ISet<GameConnection> connections = Connections[gameId];
                    if (RemoveFromSet(gameId, connections, connectionId))
                    {
                        return gameId;
                    }
                }
            }

            return -1;
        }

        private bool RemoveFromSet(int gameId, ISet<GameConnection> connections, string connectionId)
        {
            lock (connections)
            {
                foreach (GameConnection conn in connections)
                {
                    if (conn.ConnectionId.Equals(connectionId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        connections.Remove(conn);

                        if (connections.Count < 1)
                        {
                            Connections.Remove(gameId);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public IList<string> GetConnectionIds(int gameId)
        {
            ISet<GameConnection> cnns;
            if (Connections.TryGetValue(gameId, out cnns))
            {
                return cnns.Select(x => x.ConnectionId).Distinct().ToList();
            }

            return new List<string>();
        }

        public IList<string> GetUserNames(int gameId)
        {
            ISet<GameConnection> cnns;
            if (Connections.TryGetValue(gameId, out cnns))
            {
                return cnns.Select(x => x.UserName).Distinct().ToList();
            }

            return new List<string>();
        }
    }
}