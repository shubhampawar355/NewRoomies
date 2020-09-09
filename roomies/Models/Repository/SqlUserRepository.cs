using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly RoomiesDbContext Db;

        public SqlUserRepository(RoomiesDbContext roomiesDbContext)
        {
            this.Db = roomiesDbContext;
        }
        public User AddUser(User user)
        {
            Db.Users.Add(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            var temp = GetUser(user.UserId);
            if (temp != null)
                Db.Users.Remove(temp);
            return temp;
        }

        public User GetUser(int id)
        {
            return Db.Users.Where(u=>u.UserId==id)
                .Include(u=>u.Rooms)
                .ThenInclude(rooms=>rooms.Requests)
                .Include(u=>u.RequstedRooms).SingleOrDefault();
        }

        public User LogIn(string email, string pass)
        {
            return Db.Users.SingleOrDefault(u => u.Email.Equals(email) && u.Password.Equals(pass));
        }

        public void RemoveRequest(User user, Room r)
        {
           Room room=Db.Rooms.Find(r);
            if (room != null)
            {
                UserRoom userroom = new UserRoom();
                userroom.User = user;
                userroom.Room = room;
                userroom.RoomId = room.RoomId;
                userroom.UserId = user.UserId;
                room.Requests.Remove(userroom);
                user.RequstedRooms.Remove(userroom);
                Db.SaveChanges();
            }
            
        }

        public void RequestRoom(User user, Room r)
        {
            Room room=Db.Rooms.Find(r);
            if(room!=null)
            {
                UserRoom userroom = new UserRoom();
                userroom.User = user;
                userroom.Room = room;
                userroom.RoomId = room.RoomId;
                userroom.UserId = user.UserId;
                room.Requests.Add(userroom);
                user.RequstedRooms.Add(userroom);
                Db.SaveChanges();
            }
        }

        public User UpdateUSer(User user)
        {
            var entity = Db.Users.Attach(user);
            entity.State = EntityState.Modified;
            return user;
        }
    }
}
