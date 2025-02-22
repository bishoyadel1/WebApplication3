using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
     public class Payment
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
