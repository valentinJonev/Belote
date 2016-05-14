using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.Common;
using Belot.Backend.Context;
using Belot.Backend.Models;
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
        public async Task<int> CreateAsync(RoomViewModel model, IPrincipal principal)
        {
            IdentityUser user = await context.Users.SingleAsync(x => x.UserName == principal.Identity.Name);

            User player = await context.Players.Where(t => t.UserId == user.Id).FirstOrDefaultAsync();

            Room room = new Room()
            {
                Name = model.Name,
                IsChatAvaiable = model.IsChatAvaiable
            };
            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            return room.Id;
        }

        public async Task<RoomViewModel> GetAsync(int roomId)
        {
            Room room = await context.Rooms.Where(t => t.Id == roomId).FirstOrDefaultAsync();
            List<UserViewModel> players = new List<UserViewModel>();
            foreach (User player in room.PlayersId)
            {
                UserViewModel playerModel = new UserViewModel();
                playerModel.UserId = player.UserId;

                players.Add(playerModel);
            }
            RoomViewModel model = new RoomViewModel()
            {
                IsChatAvaiable = room.IsChatAvaiable,
                Name = room.Name,
                Id = room.Id,
                Players = players
            };

            return model;
        }

        public async Task Join(int roomId, IPrincipal principal)
        {
            IdentityUser user = await context.Users.SingleAsync(x => x.UserName == principal.Identity.Name);

            User player = await context.Players.Where(t => t.UserId == user.Id).FirstOrDefaultAsync();

            player.GameFK = roomId;
            await context.SaveChangesAsync();
        }
    }
}
