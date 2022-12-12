using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class City
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Division")]
        public int? DId { get; set; }
       
        public virtual Division Division { get; set; }

        public virtual List<Hotel> Hotels { get; set; }
        public virtual List<RentCar> RentCars { get; set; }
        public City()
        {
            Hotels = new List<Hotel>();

            RentCars = new List<RentCar>();
        }
    }
}
