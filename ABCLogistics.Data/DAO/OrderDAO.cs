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

        private ABCLogisticsDataEntities _context;

        public OrderDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addOrder
        public void addOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getOrders
        public IList<Order> getOrders()
        {
            IQueryable<Order> _orders;
            _orders = from order
                     in _context.Orders
                      select order;
            return _orders.ToList<Order>();
        }

        // getOrder
        public Order getOrder(int id)
        {
            IQueryable<Order> _order;
            _order = from order
                     in _context.Orders
                     where order.PK_OrderID == id
                     select order;
            return _order.ToList<Order>().First();
        }


        // UPDATE ====================================================================
        // editOrder
        public void editOrder(Order order)
        {
            Order record = (from rec
                              in _context.Orders
                            where rec.PK_OrderID == order.PK_OrderID
                            select rec).ToList<Order>().First();
            record.DateDelivered = order.DateDelivered;
            record.DateOrdered = order.DateOrdered;
            record.FK_BranchAddressID = order.FK_BranchAddressID;
            record.FK_CustomerID = order.FK_CustomerID;
            record.FK_DeliveryAddressID = order.FK_DeliveryAddressID;
            record.FK_ItemID = order.FK_ItemID;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteOrder
        public void deleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

    }
}
