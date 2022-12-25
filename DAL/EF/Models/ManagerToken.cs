using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class ManagerToken
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Required]
        public string TKey { get; set; }

        [Required]
        public System.DateTime CreationTime { get; set; }

        [Required]
        public Nullable<System.DateTime> ExpirationTime { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
