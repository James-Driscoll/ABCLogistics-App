using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;
using ABCLogistics.Data.BEANS;


namespace ABCLogistics.Data.DAO
{
    
    public class ParcelDAO : IParcelDAO
    {

        private ABCLogisticsDataEntities _context;

        // CONSTRUCTOR ===============================================================
        public ParcelDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addParcel : Method to add a new Parcel to the database.
        public void addParcel(Parcel parcel)
        {
            _context.Parcels.Add(parcel);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getParcels : Returns IList of all parcels of type Parcel.
        public IList<Parcel> getParcels()
        {
            IQueryable<Parcel> _parcels;
            _parcels = from Parcel
                          in _context.Parcels
                       select Parcel;
            return _parcels.ToList<Parcel>();
        }

        // getCustomerParcels : Returns IList of OrderBEAN parcels for a specific customer.
        public IList<ABCLogistics.Data.BEANS.OrderBEAN> getCustomerParcels(string customer)
        {
            IQueryable<OrderBEAN> _orderBEANs;
            _orderBEANs = from parcel in _context.Parcels
                          where parcel.Customer == customer
                          select new OrderBEAN
                          {
                              Id = parcel.Id,
                              Weight = parcel.Weight,
                              Insured = parcel.Insured,
                              DateOrdered = parcel.DateOrdered,
                              CustomerName = parcel.Customer
                          };
            return _orderBEANs.ToList<OrderBEAN>();
        }

        // getParcel
        public Parcel getParcel(int id)
        {
            IQueryable<Parcel> _parcel;
            _parcel = from parcel
                          in _context.Parcels
                      where parcel.Id == id
                      select parcel;
            return _parcel.ToList<Parcel>().First();
        }

        // UPDATE ====================================================================
        // editParcel
        public void editParcel(Parcel parcel)
        {
            Parcel record = (from rec
                             in _context.Parcels
                             where rec.Id == parcel.Id
                             select rec).ToList<Parcel>().First();
            record.Customer = parcel.Customer;
            record.DateOrdered = parcel.DateOrdered;
            record.Weight = parcel.Weight;
            record.Insured = parcel.Insured;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteParcel
        public void deleteParcel(Parcel parcel)
        {
            _context.Parcels.Remove(parcel);
            _context.SaveChanges();
        }

    }

}
