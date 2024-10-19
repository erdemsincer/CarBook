using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public Car Cars { get; set; }
        public string Detail { get; set; }
         

    }
}
