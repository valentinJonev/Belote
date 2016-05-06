using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Belot.WebApi.ConnectionManagers;
    
namespace Belot.WebApi
{
    [HubName("GameHub")]
    [Authorize]
    public class UsersListHub : Hub
    {
        private static readonly GameConnectionManager manager = new GameConnectionManager();

        public override Task OnDisconnected(bool stopCalled)
        {
            int gameId = manager.RemoveConnection(Context.ConnectionId);
            if (gameId > 0)
            {
                Notify(gameId);
            }

            return Task.FromResult<object>(null);
        }

        public void RegisterConnection(int gameId)
        {
            manager.AddConnection(gameId, Context.ConnectionId, Context.Request.User.Identity.Name);
            Notify(gameId);
        }

        public void Notify(int gameId)
        {
            IList<string> cnnIds = manager.GetConnectionIds(gameId);
            IList<string> userNames = manager.GetUserNames(gameId);
            Clients.Clients(cnnIds).handleNotification(gameId, userNames);
        }
    }
}
