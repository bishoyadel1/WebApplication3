using Domin.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name Required")]

        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Description Name Required")]
        [MaxLength(100)]
        public string ProductDescription { get; set; }


        [ForeignKey("CategoryId")]
 
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
