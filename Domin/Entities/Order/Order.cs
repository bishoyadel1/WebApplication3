using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public bool IsPaymentReceived { get; set; } = false;
        public bool IsPending { get; set; } = true;
        public Address Address { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
