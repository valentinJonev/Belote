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
    public class GameService
    {
        private BelotContext context;

        public GameService(BelotContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(GameCreateModel model, IPrincipal principal)
        {
            IdentityUser user = await context.Users.SingleAsync(x => x.UserName == principal.Identity.Name);

            Game game = this.ModelToGame(model, user.Id);
            context.Games.Add(game);
            await context.SaveChangesAsync();

            return game.Id;
        }

        private Game ModelToGame(GameCreateModel model, string userId)
        {
            Game game = new Game();
            game.ModeFK = model.GameMode.Id;
            game.Users = new List<User>()
            {
                new User(userId)
            };

            return game;
        }

        public async Task PlayCard(int id, IPrincipal principal)
        {
            IdentityUser user = await context.Users.SingleAsync(x => x.UserName == principal.Identity.Name);

            Game game = await context.Games.Where(t => t.Users.Any(l => l.UserId == user.Id)).FirstOrDefaultAsync();
            GameCard playedcard = new GameCard()
            {
                CardFK = id,
                PlayerFK = user.Id,
                Turn = game.CurrentTurn
            };
            game.PlayedCards.Add(playedcard);

            await context.SaveChangesAsync();
        }

        public async Task<GameDetailsModel> GetAsync(int id)
        {
            Game game = await this.context.Games.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (game == null)
            {
                throw new EntityNotFoundException();
            }

            return new GameDetailsModel(game);
        }
    }
}
