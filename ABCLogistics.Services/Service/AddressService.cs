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

    public class AddressService : IAddressService
    {

        private AddressDAO _addressDAO;
        public AddressService()
        {
            _addressDAO = new AddressDAO();
        }

        // CREATE ===================================================================
        // addAddress
        public void addAddress(Address address)
        {
            _addressDAO.addAddress(address);
        }

        // READ =====================================================================
        // getAddresses
        public IList<Address> getAddresses()
        {
            return _addressDAO.getAddresses();
        }

        // getAddress
        public Address getAddress(int id)
        {
            return _addressDAO.getAddress(id);
        }

        // UPDATE ===================================================================
        // editAddress
        public void editAddress(Address address)
        {
            _addressDAO.editAddress(address);
        }

        // DELETE ===================================================================
        // deleteAddress
        public void deleteAddress(Address address)
        {
            _addressDAO.deleteAddress(address);
        }

    }

}
