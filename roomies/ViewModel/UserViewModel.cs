using roomies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Room> Rooms { get; set; }

    }

}
