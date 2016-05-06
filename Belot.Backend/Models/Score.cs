using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Models
{
    public class Score
    {
        public int Id { get; set; }

        public int TeamA { get; set; }

        public int TeamB { get; set; }

        public int Turn { get; set; }

        public int GameFK { get; set; }
    }
}
