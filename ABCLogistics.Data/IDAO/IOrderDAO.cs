using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.IDAO
{
    interface IOrderDAO
    {
        IList<Order_Branch> getOrderBranches();
        IList<Order_Parcel> getOrderParcels(string BranchName);
    }
}