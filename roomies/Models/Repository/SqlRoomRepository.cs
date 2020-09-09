using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{
    public class SqlRoomRepository: IRoomRepository
    {
        private readonly RoomiesDbContext Db;

        public SqlRoomRepository(RoomiesDbContext roomiesDbContext)
        {
            this.Db = roomiesDbContext;
        }

        public ICollection<Room> AllRooms => throw new NotImplementedException();

        public Room AddRoom(User user, Room room)
        {
            room.Owner = user;
            room.OwnerId = user.UserId;
            Db.Rooms.Add(room);
            return room;
        }

        public Room DeleteRoom(Room room)
        {
            var user = Db.Users.Find(room.OwnerId);
            //user.Rooms.Remove(room);
            Db.Rooms.Remove(room);
            Db.SaveChanges();
            return room;
        }

        public Room GetRoom(int roomId)
        {
            return Db.Rooms.Include(r=>r.Location).Include(r=>r.Owner).Where(r=>r.RoomId==roomId).FirstOrDefault();
        }

        public Room GetRoomRequests(Room room)
        {
            return Db.Rooms.Where(r => r.RoomId == room.RoomId).Include(r => r.Requests).FirstOrDefault();
        }

        public ICollection<Room> GetRooms(string city)
        {
            List<Room> lists = Db.Rooms.Where(r=>r.Location.City.Equals(city))
                .Include(r=>r.Location)
                .Include(r=>r.Owner).ToList();
            return lists;
        }

        public ICollection<Room> GetRoomsByFilter(Filter filter)
        {
           return Db.Rooms.Where(r=>r.Rent<=filter.MaxBudget && r.Rent>=filter.MinBudget
                                 && r.RoomCount<=filter.MaxRoomCount && r.RoomCount>=filter.MinRoomCount
                                 && r.SharingCount<=filter.MaxSharingCount && r.SharingCount>=filter.MinSharingCount
                                 && r.Type==filter.type).ToList();
        }

        public ICollection<Room> GetUserRooms(User user)
        {
           return Db.Rooms.Where(r => r.OwnerId == user.UserId)
                .Include(r => r.Requests).Include(r => r.Location).ToList();
        }

        public List<Room> GetUsersAllRoomsRequests(User user)
        {
            return Db.Rooms.Where(r => r.OwnerId == user.UserId)
                         .Include(r => r.Requests).Include(r => r.Location).ToList();
        }

        public Room UpdateRoom(Room room)
        {
            var entity = Db.Rooms.Attach(room);
            entity.State = EntityState.Modified;
            return room;
        }
    }
}
