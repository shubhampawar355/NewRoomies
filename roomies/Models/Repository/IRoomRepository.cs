using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{
    public interface IRoomRepository
    {
        Room GetRoom(int roomId);
        Room AddRoom(User user, Room room);
        Room UpdateRoom(Room room);
        Room DeleteRoom(Room room);
        ICollection<Room> AllRooms { get; }
        ICollection<Room> GetRooms(String city);
        ICollection<Room> GetRoomsByFilter(Filter filter);
        ICollection<Room> GetUserRooms(User user);
        Room GetRoomRequests(Room room);
        List<Room> GetUsersAllRoomsRequests(User user);
    }
}
