using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.Common;
using Belot.Backend.Context;
using Belot.Backend.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Belot.Backend.Services
{
    public class RoomService : BaseService
    {
        private BelotContext context;

        public RoomService(BelotContext context)
        {
            this.context = context;
        }
        public async Task<string> CreateAsync(IPrincipal principal)
        {
#warning TODO: implement room id generator and insert the room in DB
            string roomId = "asdf";
            this.Join(roomId, principal);
            return roomId;
        }

        public async Task<RoomViewModel> GetAsync(string roomId)
        {
#warning TODO: Get the room details and return them in the view model
            return new RoomViewModel();
        }

        public async Task Join(string roomId, IPrincipal principal)
        {
#warning TODO: implement join 

            IdentityUser user = await context.Users.SingleAsync(x => x.UserName == principal.Identity.Name);
        }
    }
}
