using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Services.IService;
using ABCLogistics.Data;
using ABCLogistics.Data.DAO;

namespace ABCLogistics.Services.Service
{
    public class OrderService : IOrderService
    {

        private OrderDAO _orderDAO;
        
        public OrderService()
        {
            _orderDAO = new OrderDAO();
        }

        public IList<Order_Branch> getOrderBranches()
        {
            return _orderDAO.getOrderBranches();
        }

    }

}