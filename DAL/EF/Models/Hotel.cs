using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual List<Room> Rooms { get; set; }
        public Hotel()
        {
            Rooms = new List<Room>();
        }

    }
}
