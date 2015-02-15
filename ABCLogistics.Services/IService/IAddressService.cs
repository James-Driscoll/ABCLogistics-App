using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{

    interface IAddressService
    {

        // CREATE ===================================================================
        // addAddress
        void addAddress(Address address);

        // READ =====================================================================
        // getAddresses
        IList<Address> getAddresses();

        // getAddress
        Address getAddress(int id);

        // UPDATE ===================================================================
        // editAddress
        void editAddress(Address address);

        // DELETE ===================================================================
        // deleteAddress
        void deleteAddress(Address address);

    }

}
