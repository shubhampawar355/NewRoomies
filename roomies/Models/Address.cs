using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public int FlatNo { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string PinCode { get; set; }

        public virtual Room room { get; set; }
    }
}
