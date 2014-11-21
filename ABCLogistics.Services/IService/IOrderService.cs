using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{
    interface IOrderService
    {
        IList<Order_Branch> getOrderBranches();
        IList<Order_Parcel> getOrderParcels(string BranchName);
    }
}
