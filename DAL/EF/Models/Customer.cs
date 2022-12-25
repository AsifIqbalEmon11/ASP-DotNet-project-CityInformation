using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Gender { get; set; }
        [StringLength(200)]
        [Required]
        public string DOB { get; set; }

        [StringLength(20)]
        [Required]
        public string Username { get; set; }
        [StringLength(20)]
        [Required]
        public string Password { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual List<CustomerToken> CustomerTokens { get; set; }

        public Customer()
        {
            CustomerTokens = new List<CustomerToken>();
        }
    }
}
