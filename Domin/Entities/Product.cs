using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public class Product 
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name Required")]

        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Description Name Required")]
        [MaxLength(100)]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Product Price  Required")]

        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        public int  CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string  ImageUrl { get; set; }
    }

}
