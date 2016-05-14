using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.Models;

namespace Belot.Backend.ViewModels
{
    public class GameModeViewModel
    {
        public GameModeViewModel(GameMode model)
        {
#warning TODO: Implemet GameModeViewModel
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int PlayersRequired { get; set; }
    }
}
