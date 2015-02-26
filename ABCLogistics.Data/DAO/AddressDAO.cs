using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

namespace ABCLogistics.Data.DAO
{

    public class AddressDAO : IAddressDAO
    {

        private ABCLogisticsDataEntities _context;

        public AddressDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addAddress
        public void addAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getAddresses
        public IList<Address> getAddresses()
        {
            IQueryable<Address> _addresses;
            _addresses = from address
                          in _context.Addresses
                         select address;
            return _addresses.ToList<Address>();
        }

        // getAddress
        public Address getAddress(int id)
        {
            IQueryable<Address> _address;
            _address = from address
                          in _context.Addresses
                       where address.PK_AddressID == id
                       select address;
            return _address.ToList<Address>().First();
        }

        // UPDATE ====================================================================
        // editAddress
        public void editAddress(Address address)
        {
            Address record = (from rec
                                      in _context.Addresses
                              where rec.PK_AddressID == address.PK_AddressID
                              select rec).ToList<Address>().First();
            record.Name = address.Name;
            record.AddressLine1 = address.AddressLine1;
            record.AddressLine2 = address.AddressLine2;
            record.Town = address.Town;
            record.County = address.County;
            record.Postcode = address.Postcode;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteAddress
        public void deleteAddress(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

    }

}
