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
       
        private db_ABCLogisticsEntities _context;
        
        public OrderDAO()
        {
            _context = new db_ABCLogisticsEntities();
        }

        public IList<Branch> getOrderBranches()
        {
            IQueryable<Branch> _branches;
            _branches = from branch
                        in _context.Branches
                        select branch;
            return _branches.ToList<Branch>();
        }

    }

}
