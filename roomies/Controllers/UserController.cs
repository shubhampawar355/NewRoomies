using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using roomies.models.Enums;
using roomies.Models;
using roomies.Models.Repository;
using roomies.ViewModel;

namespace roomies.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IRoomRepository roomRepository;

        public IHtmlHelper HtmlHelper { get; }
        public IEnumerable<SelectListItem> GenderList { get; set; }
        public IEnumerable<SelectListItem> PropTypeList { get; set; }
        public User CUser { get; set; }

        public UserController(IUserRepository userRepository,IRoomRepository roomRepository, IHtmlHelper htmlHelper)
        {
            this.userRepository = userRepository;
            this.roomRepository = roomRepository;
            HtmlHelper = htmlHelper;
            GenderList = htmlHelper.GetEnumSelectList<Gender>();
            PropTypeList = htmlHelper.GetEnumSelectList<PropertyType>();
        }
        public ViewResult Register()
        {
            return View(new RegisterViewModel(GenderList));
        }
        [HttpPost]
        public IActionResult AfterRegister()
        {
            return RedirectToAction(actionName: "LogIn");
        }

        public ViewResult LogIn()
        {
            return View();
        }

        public ViewResult ValidateUser(User user)
        {
            CUser=userRepository.LogIn(user.Email, user.Password);
            if (CUser != null)
            {
                HomeViewModel model = new HomeViewModel(CUser,PropTypeList);
                model.rooms = roomRepository.GetRooms("pune");
                if (CUser.Filter == null)
                    CUser.Filter = new Filter();
                return View("Home", model);
            }
            else
                return View("NotFound");
        }

        public ViewResult Home()
        {
            return View();
        }
        public ViewResult ViewRoom(int id)
        {
            Room room=roomRepository.GetRoom(id);
            return View(new RoomCardModel(room));
        }


    }
}
