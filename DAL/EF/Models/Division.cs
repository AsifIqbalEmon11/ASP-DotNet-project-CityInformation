using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Division
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual List<City> Citys { get; set; }
        public Division()
        {
            Citys = new List<City>();
        }
    }
}
