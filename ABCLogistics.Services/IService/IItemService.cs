using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{

    interface IItemService
    {

        // CREATE ===================================================================
        // addItem
        void addItem(Item item);

        // READ =====================================================================
        // getItems
        IList<Item> getItems();

        // getItem
        Item getItem(int id);

        // UPDATE ===================================================================
        // editItem
        void editItem(Item item);

        // DELETE ===================================================================
        // deleteItem
        void deleteItem(Item item);

    }

}
