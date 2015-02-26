using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Services.IService;
using ABCLogistics.Data;
using ABCLogistics.Data.DAO;
using ABCLogistics.Data.BEANS;

namespace ABCLogistics.Services.Service
{

    public class ParcelService : IParcelService
    {

        private ParcelDAO _parcelDAO;

        public ParcelService()
        {
            _parcelDAO = new ParcelDAO();
        }

        // CREATE ===================================================================
        // addParcel
        public void addParcel(Parcel parcel)
        {
            _parcelDAO.addParcel(parcel);
        }

        // READ =====================================================================
        // getParcels : Returns IList of all parcels of type Parcel.
        public IList<Parcel> getParcels()
        {
            return _parcelDAO.getParcels();
        }
        
        // getCustomerParcels : Returns IList of OrderBEAN parcels for a specific customer.
        public IList<ABCLogistics.Data.BEANS.OrderBEAN> getCustomerParcels(int customer)
        {
            return _parcelDAO.getCustomerParcels(customer);
        }

        // getParcel
        public Parcel getParcel(int id)
        {
            return _parcelDAO.getParcel(id);
        }

        // UPDATE ===================================================================
        // editParcel
        public void editParcel(Parcel parcel)
        {
            _parcelDAO.editParcel(parcel);
        }

        // DELETE ===================================================================
        // deleteParcel
        public void deleteParcel(Parcel parcel)
        {
            _parcelDAO.deleteParcel(parcel);
        }

    }
}
