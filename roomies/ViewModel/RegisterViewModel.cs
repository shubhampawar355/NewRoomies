using Microsoft.AspNetCore.Mvc.Rendering;
using roomies.models.Enums;
using roomies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.ViewModel
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }

        public RegisterViewModel(IEnumerable<SelectListItem> gender)
        {
            User = new User();
            Gender = gender;
        }
    }
}
