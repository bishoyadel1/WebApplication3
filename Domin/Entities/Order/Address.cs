using Microsoft.EntityFrameworkCore;

namespace Domin.Entities.Order
{
    [Owned]
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
 
    }
}