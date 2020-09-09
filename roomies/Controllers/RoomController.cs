using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roomies.Models.Repository;

namespace roomies.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public IActionResult AllRooms()
        {
            return View(roomRepository.GetRooms("pune"));
        }
    }
}
