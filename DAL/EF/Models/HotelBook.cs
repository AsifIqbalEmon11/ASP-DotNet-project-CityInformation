using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class HotelBook
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        public string CheckIn { get; set; }
        public string Checkout { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
