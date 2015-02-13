using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.IDAO
{

    interface IOrderDAO
    {

        // CREATE ====================================================================
        // addOrder
        void addOrder(Order order);

        // READ ======================================================================
        // getOrders
        IList<Order> getOrders();

        // getOrder
        Order getOrder(int id);

        // UPDATE ====================================================================
        // editOrder
        void editOrder(Order order);

        // DELETE ====================================================================
        // deleteOrder
        void deleteOrder(Order order);

    }

}
