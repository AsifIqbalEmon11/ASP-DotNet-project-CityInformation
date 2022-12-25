using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class AdminToken
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string TKey { get; set; }
       
        [Required]
        public System.DateTime CreationTime { get; set; }
        
        [Required]
        public Nullable<System.DateTime> ExpirationTime { get; set; }

        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
