using Microsoft.AspNetCore.Mvc.Rendering;
using roomies.Models;
using roomies.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.ViewModel
{
    public class HomeViewModel
    {
        public ICollection<Room> rooms { get; set; }
        public User CUser { get; set; }
        public Filter Filter { get; set; }
        public IEnumerable<SelectListItem> PropTypeList { get; set; }


        public HomeViewModel(User cUser, IEnumerable<SelectListItem> propTypeList)
        {
            CUser = cUser;
            rooms = CUser.Rooms;
            Filter = cUser.Filter;
            PropTypeList = propTypeList;
        }
    }
}
