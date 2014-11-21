using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

namespace ABCLogistics.Data.DAO
{
    public class OrderDAO : IOrderDAO
    {
       
        private db_ABCLogisticsEntities2 _context;
        
        public OrderDAO()
        {
            _context = new db_ABCLogisticsEntities2();
        }

        public IList<Order_Branch> getOrderBranches()
        {
            IQueryable<Order_Branch> _branches;
            _branches = from branch
                        in _context.Order_Branch
                        select branch;
            return _branches.ToList<Order_Branch>();
        }

        public IList<Order_Parcel> getOrderParcels(string BranchName)
        {
            IQueryable<Order_Parcel> _parcels;
            _parcels = from parcel
                       in _context.Order_Parcel
                       where parcel.BranchName == BranchName
                       select parcel;
            return _parcels.ToList<Order_Parcel>();
        }

    }

}