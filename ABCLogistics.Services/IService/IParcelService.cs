using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{

    interface IParcelService
    {

        // CREATE ===================================================================
        // addParcel
        void addParcel(Parcel parcel);

        // READ =====================================================================
        // getParcels
        IList<Parcel> getParcels();

        // getParcel
        Parcel getParcel(int id);

        // UPDATE ===================================================================
        // editParcel
        void editParcel(Parcel parcel);

        // DELETE ===================================================================
        // deleteParcel
        void deleteParcel(Parcel parcel);

    }

}
