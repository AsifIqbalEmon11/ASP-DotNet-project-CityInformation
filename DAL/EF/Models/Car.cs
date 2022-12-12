using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Required]
        
        public double Rent { get; set; }

        [ForeignKey("RentCar")]
        public int? RentId { get; set; }
        public virtual RentCar RentCar { get; set; }
    }
}
