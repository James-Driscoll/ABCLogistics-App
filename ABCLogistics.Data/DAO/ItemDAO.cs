using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

namespace ABCLogistics.Data.DAO
{

    public class ItemDAO : IItemDAO
    {

        private ABCLogisticsDataEntities _context;

        public ItemDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addItem
        public void addItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getItems
        public IList<Item> getItems()
        {
            IQueryable<Item> _items;
            _items = from item
                     in _context.Items
                     select item;
            return _items.ToList<Item>();
        }

        // getItem
        public Item getItem(int id)
        {
            IQueryable<Item> _item;
            _item = from item
                     in _context.Items
                    where item.PK_ItemID == id
                    select item;
            return _item.ToList<Item>().First();
        }

        // UPDATE ====================================================================
        // editItem
        public void editItem(Item item)
        {
            Item record = (from rec
                              in _context.Items
                           where rec.PK_ItemID == item.PK_ItemID
                           select rec).ToList<Item>().First();
            record.Name = item.Name;
            record.Insured = item.Insured;
            record.RecordedDelivery = item.RecordedDelivery;
            record.SizeCategory = item.SizeCategory;
            record.Type = item.Type;
            record.Weight = item.Weight;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteItem
        public void deleteItem(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

    }

}
