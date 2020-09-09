using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{
    public interface IUserRepository
    {
		User AddUser(User user);
		User GetUser(int id);
		User UpdateUSer(User user);
		User DeleteUser(User user);
		User LogIn(String email, String pass);
		void RequestRoom(User user,Room room);
		void RemoveRequest(User user, Room room);
	}
}
