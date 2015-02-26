using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.IDAO
{

    interface IParcelDAO
    {

        // CREATE ====================================================================
        // addParcel
        void addParcel(Parcel parcel);

        // READ ======================================================================
        // getParcels : Returns IList of all parcels of type Parcel.
        IList<Parcel> getParcels();

        // getCustomerParcels : Returns IList of OrderBEAN parcels for a specific customer.
        IList<ABCLogistics.Data.BEANS.OrderBEAN> getCustomerParcels(int customer);

        // getParcel
        Parcel getParcel(int id);

        // UPDATE ====================================================================
        // editParcel
        void editParcel(Parcel parcel);

        // DELETE ====================================================================
        // deleteParcel
        void deleteParcel(Parcel parcel);

    }

}
