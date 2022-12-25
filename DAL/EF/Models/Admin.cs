using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Admin
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

        public virtual List<Manager> Managers { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<AdminToken> AdminTokens { get; set; }
        public Admin()
        {
            AdminTokens = new List<AdminToken>();
            Managers = new List<Manager>();
            Customers = new List<Customer>();
        }
        
        


    }
}
