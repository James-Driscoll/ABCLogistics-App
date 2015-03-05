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
        //public IList<Parcel> getParcels()
        //{
        //    IQueryable<Parcel> _parcels;
        //    _parcels = from Parcel
        //               in _context.Parcels
        //               select Parcel;
        //    return _parcels.ToList<Parcel>();
        //}
        public IList<OrderBEAN> getParcels()
        {
            IQueryable<OrderBEAN> _orderBEANs;
            _orderBEANs = from parcels in _context.Parcels
                          from branches in _context.Branches
                          where parcels.Branch == branches.Id
                          select new OrderBEAN
                          {
                              Id = parcels.Id,
                              Weight = parcels.Weight,
                              Insured = parcels.Insured,
                              DateOrdered = parcels.DateOrdered,
                              DateDelivered = parcels.DateDelivered,
                              Status = parcels.Status,
                              Customer = parcels.Customer,
                              BranchName = branches.Name
                          };
            return _orderBEANs.ToList<OrderBEAN>();
        }

        // getCustomerParcels : Returns IList of OrderBEAN parcels for a specific customer.
        public IList<OrderBEAN> getCustomerParcels(string customer)
        {
            IQueryable<OrderBEAN> _orderBEANs;
            _orderBEANs = from parcels in _context.Parcels
                          from branches in _context.Branches
                          where parcels.Customer == customer
                          where parcels.Branch == branches.Id
                          select new OrderBEAN
                          {
                              Id = parcels.Id,
                              Weight = parcels.Weight,
                              Insured = parcels.Insured,
                              DateOrdered = parcels.DateOrdered,
                              DateDelivered = parcels.DateDelivered,
                              Status = parcels.Status,
                              Customer = parcels.Customer,
                              BranchName = branches.Name
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
            record.Branch = parcel.Branch;
            record.DateOrdered = parcel.DateOrdered;
            record.DateDelivered = parcel.DateDelivered;
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
