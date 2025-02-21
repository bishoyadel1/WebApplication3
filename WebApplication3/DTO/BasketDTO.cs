using Domin.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO
{
    public class BasketDTO
    {
 
        public int ProductId { get; }
  
        public int ProductCount { get; set; }

    }
}
