using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Models
{
    public class User
    {
        public User(string userId)
        {
            this.UserId = userId;
        }
        public int Id { get; set; }

        public string UserId { get; set; }

        public int GameFK { get; set; }
    }
}
