using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities
{
    public  class Trainer
    { 
            public int Id { get; set; }
            public string Name { get; set; }
            public string Expertise { get; set; }
            public ICollection<Course> Courses { get; set; } = new List<Course>();
       
    }
}
