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
        // getParcels
        IList<Parcel> getParcels();

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
