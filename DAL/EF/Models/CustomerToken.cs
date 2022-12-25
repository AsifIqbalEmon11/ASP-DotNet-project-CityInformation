using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class CustomerToken
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string TKey { get; set; }

        [Required]
        public System.DateTime CreationTime { get; set; }

        [Required]
        public Nullable<System.DateTime> ExpirationTime { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
