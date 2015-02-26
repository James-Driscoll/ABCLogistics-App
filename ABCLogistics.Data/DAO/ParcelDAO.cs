using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

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
        // addParcel
        public void addParcel(Parcel parcel)
        {
            _context.Parcels.Add(parcel);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getParcels
        public IList<Parcel> getParcels()
        {
            IQueryable<Parcel> _parcels;
            _parcels = from Parcel
                          in _context.Parcels
                     select Parcel;
            return _parcels.ToList<Parcel>();
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
            record.CustomerName = parcel.CustomerName;
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
