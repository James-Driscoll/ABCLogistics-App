using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.IDAO
{

    interface IAddressDAO
    {

        // CREATE ====================================================================
        // addAddress
        void addAddress(Address address);

        // READ ======================================================================
        // getAddresses
        IList<Address> getAddresses();

        // getAddress
        Address getAddress(int id);

        // UPDATE ====================================================================
        // editAddress
        void editAddress(Address address);

        // DELETE ====================================================================
        // deleteAddress
        void deleteAddress(Address address);

    }

}
