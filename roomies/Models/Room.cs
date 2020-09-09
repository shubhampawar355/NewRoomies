using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using roomies.models.Enums;

namespace roomies.Models
{
	public class Room
	{
		public int RoomId { get; set; }
		public virtual Address Location { get; set; }
		public String Description { get; set; }

        public float Rent { get; set; }
		public VisiblityStatus VisiblityStatus { get; set; }
		public ValidStatus ValidateStatus { get; set; } = ValidStatus.NONE;

		public int OwnerId { get; set; }
		//reverse link for many to one
		public User Owner { get; set; }
		//many to one

		public ISet<UserRoom> Requests { get; set; }= new HashSet<UserRoom>();
		//many to many

		public DateTime PostDate { get; set; }
		public PropertyType Type { get; set; }
		public int RoomCount { get; set; }
		public int SharingCount { get; set; }
	}
}
