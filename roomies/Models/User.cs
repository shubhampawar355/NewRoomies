using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using roomies.models.Enums;

namespace roomies.Models
{
    public class User
    {
		public int UserId { get; set; }
		[Required(ErrorMessage = "Please enter your Full Name")]
		[Display(Name = "Full Name")]
		[StringLength(50)]
		public String Name { get; set; }
		[Required(ErrorMessage = "Please enter Email Id")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		[Display(Name = "Email Id")]
		[StringLength(50)]
		public String Email { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public String Password { get; set; }
		[Required]
		[Compare("Password")]
		[Display(Name = "Confirm Password")]
		public String ConfirmPassword{ get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Phone Number")]
		public String PhoneNo { get; set; }
		[Required]
		public Gender Gender { get; set; }	
        public virtual ISet<Room> Rooms { get; set; } = new HashSet<Room>();
		//one to many
		public virtual ISet<UserRoom> RequstedRooms { get; set; }= new HashSet<UserRoom>();
		//many to many
		public virtual Filter Filter { get; set; }
	}
}
