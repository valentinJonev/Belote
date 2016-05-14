using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.ViewModels
{
    public class GameCreateModel
    {
        public GameModeViewModel GameMode { get; set; }

        public int PlayerId { get; set; }

        public string Name { get; set; }
    }
}
