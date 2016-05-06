using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Belot.Auth.ConnectionManagers
{
    public class UserConnectionManager
    {
        public UserConnectionManager()
        {
            Connections = new Dictionary<string, UserConnection>();
        }

        // <userId, Connection>
        public IDictionary<string, UserConnection> Connections { get; private set; }

        public void AddConnection(ClaimsIdentity identity, string connecitonId)
        {
            string userId = GetUserId(identity);
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }
            
            lock (Connections)
            {
                UserConnection conn;
                if (!Connections.TryGetValue(userId, out conn))
                {
                    conn = new UserConnection(userId, identity.Name);
                    Connections.Add(userId, conn);
                }

                lock (conn)
                {
                    conn.ConnectionIds.Add(connecitonId);
                }
            }
        }

        public void RemoveConnection(ClaimsIdentity identity, string connectionId)
        {
            string userId = GetUserId(identity);
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            lock (Connections)
            {
                UserConnection conn;
                if (Connections.TryGetValue(userId, out conn)
                    && conn.ConnectionIds.Contains(connectionId))
                {
                    lock (conn)
                    {
                        conn.ConnectionIds.Remove(connectionId);
                    }

                    if (conn.ConnectionIds.Count < 1)
                    {
                        Connections.Remove(userId);
                    }
                }
            }
        }

        public UserConnection GetConnection(string userId)
        {
            UserConnection conn;
            if (Connections.TryGetValue(userId, out conn))
            {
                return conn;
            }

            return null;
        }

        public UserConnection GetConnection(ClaimsIdentity identity)
        {
            return GetConnection(GetUserId(identity));
        }

        private string GetUserId(ClaimsIdentity identity)
        {
            Claim idClaim = identity.Claims.Where(x => "user_id".Equals(x.Type)).FirstOrDefault();
            return idClaim != null ? idClaim.Value : string.Empty;
        }
    }
}