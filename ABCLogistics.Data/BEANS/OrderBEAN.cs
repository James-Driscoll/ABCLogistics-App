using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.BEANS
{
    
    public class OrderBEAN
    {

        public int Id { get; set; }
        public int Weight { get; set; }
        public Boolean Insured { get; set; }
        public DateTime DateOrdered { get; set; }
        public string CustomerName { get; set; }

        // CONSTRUCTOR ===============================================================
        public OrderBEAN() { }

    }

}
