using roomies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.ViewModel
{
    public class RoomCardModel
    {
        public Room Room { get; set; }
        public string LessDetails { get; set; }
        public RoomCardModel(Room room)
        {
            Room = room;
            LessDetails = Room.Description.Substring(0,190);
        }
    }
}
