﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsChatAvaiable { get; set; }

        public List<UserViewModel> Players { get; set; }
    }
}
