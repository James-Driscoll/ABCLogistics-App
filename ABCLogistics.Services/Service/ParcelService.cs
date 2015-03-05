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
        public void addParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            _parcelDAO.addParcel(orderBEAN);
        }

        // READ =====================================================================
        // getParcels : Returns IList of all parcels of type Parcel.
        public IList<ABCLogistics.Data.BEANS.OrderBEAN> getParcels()
        {
            return _parcelDAO.getParcels();
        }
        
        // getCustomerParcels : Returns IList of OrderBEAN parcels for a specific customer.
        public IList<ABCLogistics.Data.BEANS.OrderBEAN> getCustomerParcels(string customer)
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
        public void editParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            _parcelDAO.editParcel(orderBEAN);
        }

        // DELETE ===================================================================
        // deleteParcel
        public void deleteParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            _parcelDAO.deleteParcel(orderBEAN);
        }

    }
}
