using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Belot.Backend.Models
{
    public class Game
    {
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Score> Score { get; set; }

        public GameMode Mode { get; set; }

        public int ModeFK { get; set; }
    }
}
