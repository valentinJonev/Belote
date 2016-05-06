namespace Belot.WebApi.ConnectionManagers
{
    public class GameConnection
    {
        public GameConnection(string connectionId, string userName)
        {
            ConnectionId = connectionId;
            UserName = userName;
        }

        public string UserName { get; set; }

        public string ConnectionId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GameConnection)
            {
                return (obj as GameConnection).ConnectionId
                    .Equals(ConnectionId, System.StringComparison.InvariantCulture);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ConnectionId.GetHashCode();
        }
    }
}