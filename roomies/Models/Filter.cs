using System;
using System.Collections.Generic;
using System.Linq;
using roomies.models.Enums;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace roomies.Models
{
    public class Filter
    {
		[Key]
		[ForeignKey("User")]
		public int FilterId { get; set; }

		[Display(Name = "Minimum Rent")]
		public float MinBudget { get; set; } = 0;
		[Display(Name = "Maximum Rent")]
		public float MaxBudget { get; set; } = 353535;

		[Display(Name = "Minimum Rooms")]
		public int MinRoomCount { get; set; } = 1;
		[Display(Name = "Maximum Rooms")]
		public int MaxRoomCount { get; set; } = 10;
		[Display(Name = "Minimum Sharing")]
		public int MinSharingCount { get; set; } = 0;
		[Display(Name = "Maximum Sharing")]
		public int MaxSharingCount { get; set; } = 10;
		[Display(Name = "Property Type")]
		public PropertyType type { get; set; }
		public virtual User User { get; set; }

	}
}
