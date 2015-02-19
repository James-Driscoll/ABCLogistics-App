using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.BEANS
{
    
    public class OrderBEAN
    {

        public int PK_OrderID { get; set; }
        public int BranchName { get; set; }
        public int AddressName { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemInsuranceType { get; set; }
        public string ItemRecordedDelivery { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateDelivered { get; set; }
        public string Status { get; set; }
    }

}
