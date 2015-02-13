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

    public class ItemService : IItemService
    {

        private ItemDAO _itemDAO;

        public ItemService()
        {
            _itemDAO = new ItemDAO();
        }

        // CREATE ===================================================================
        // addItem
        public void addItem(Item item)
        {
            _itemDAO.addItem(item);
        }

        // READ =====================================================================
        // getItems
        public IList<Item> getItems()
        {
            return _itemDAO.getItems();
        }

        // getItem
        public Item getItem(int id)
        {
            return _itemDAO.getItem(id);
        }

        // UPDATE ===================================================================
        // editItem
        public void editItem(Item item)
        {
            _itemDAO.editItem(item);
        }

        // DELETE ===================================================================
        // deleteItem
        public void deleteItem(Item item)
        {
            _itemDAO.deleteItem(item);
        }

    }
}
