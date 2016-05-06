using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.ViewModels
{
    public class RoomViewModel
    {
        public string RoomId { get; set; }
        public IEnumerable<UserViewModel> Players { get; set; }
        public UserViewModel CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
