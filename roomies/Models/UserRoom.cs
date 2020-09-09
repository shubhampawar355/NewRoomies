using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models
{
    public class UserRoom
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
