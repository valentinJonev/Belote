using System.Collections.Generic;

namespace Belot.Auth.ConnectionManagers
{
    public class UserConnection
    {
        public UserConnection(string userId, string userName)
        {
            ConnectionIds = new HashSet<string>();
            User = new UserModel()
            {
                Id = userId,
                Name = userName
            };
        }

        public UserModel User { get; private set; }
        public ISet<string> ConnectionIds { get; private set; }
    }
}