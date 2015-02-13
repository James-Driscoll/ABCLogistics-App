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

        private OrderDAO _OrderDAO;

        public OrderService()
        {
            _OrderDAO = new OrderDAO();
        }

        // CREATE ===================================================================
        // addOrder
        public void addOrder(Order order)
        {
            _OrderDAO.addOrder(order);
        }

        // READ =====================================================================
        // getOrders
        public IList<Order> getOrders()
        {
            return _OrderDAO.getOrders();
        }

        // getOrder
        public Order getOrder(int id)
        {
            return _OrderDAO.getOrder(id);
        }

        // UPDATE ===================================================================
        // editOrder
        public void editOrder(Order order)
        {
            _OrderDAO.editOrder(order);
        }

        // DELETE ===================================================================
        // deleteOrder
        public void deleteOrder(Order order)
        {
            _OrderDAO.deleteOrder(order);
        }

    }

}
