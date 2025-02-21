using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class UserBasket
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }


    }

  
}
