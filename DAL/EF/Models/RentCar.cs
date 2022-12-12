using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class RentCar
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        [ForeignKey("City")]
        public int? CId { get; set; }

        public virtual City City { get; set; }
        public virtual List<Car> Cars { get; set; }
        public RentCar()
        {
            Cars = new List<Car>();
        }
    }
}
