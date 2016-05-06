using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Models
{
    public class GameMode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PlayersRequired { get; set; }
    }
}
