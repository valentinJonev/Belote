using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.Models;

namespace Belot.Backend.ViewModels
{
    public class GameDetailsModel
    {
        public int Id { get; set; }

        public IEnumerable<UserViewModel> Players { get; set; }

        public GameModeViewModel Mode { get; set; }

        public GameDetailsModel(Game game)
        {
            this.Id = game.Id;
            this.Mode = new GameModeViewModel(game.Mode);
#warning TODO: implement gameDetailsViewModel
        }
    }
}
