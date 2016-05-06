using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Models
{
    public class CardValue
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int ModeFK { get; set; }

        public int CardFK { get; set; }
    }
}
