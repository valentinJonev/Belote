using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Models
{
    public class GameCard
    {
        public int Id { get; set; }

        public Card Card { get; set; }

        public User Player { get; set; }

        public Game Game { get; set; }

        public int GameFK { get; set; }

        public string PlayerFK { get; set; }

        public int CardFK { get; set; }

        public int Turn { get; set; }
    }
}
