using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;
using ABCLogistics.Data.BEANS;

namespace ABCLogistics.Data.DAO
{

    public class TrackingDAO : ITrackingDAO
    {

        private ABCLogisticsDataEntities _context;
        
        // CONSTRUCTOR ===============================================================
        public TrackingDAO()
        {
            _context = new ABCLogisticsDataEntities();
        }

        // CREATE ====================================================================
        // addTracking
        public void addTracking(Tracking tracking)
        {
            _context.Trackings.Add(tracking);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getTrackings : Returns IList of all trackings of type OrderBEAN.
        public IList<Tracking> getTrackings()
        {
            IQueryable<Tracking> _trackings;
            _trackings = from tracking
                         in _context.Trackings
                         select tracking;
            return _trackings.ToList<Tracking>();
        }

        // getOrderTrackings : Returns IList of Tracking of a specific order.
        public IList<Tracking> getOrderTrackings(int id)
        {
            IQueryable<Tracking> _trackings;
            _trackings = from tracking
                         in _context.Trackings
                         where tracking.Order == id
                         select tracking;
            return _trackings.ToList<Tracking>();
        }

        // getTracking
        public Tracking getTracking(int id)
        {
            IQueryable<Tracking> _tracking;
            _tracking = from tracking
                     in _context.Trackings
                        where tracking.Id == id
                        select tracking;
            return _tracking.ToList<Tracking>().First();
        }

        // UPDATE ====================================================================
        // editTracking
        public void editTracking(Tracking tracking)
        {
            Tracking record = (from rec
                              in _context.Trackings
                               where rec.Id == tracking.Id
                               select rec).ToList<Tracking>().First();
            record.Order = tracking.Order;
            record.Location = tracking.Location;
            record.Date = tracking.Date;
            record.Status = tracking.Status;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteTracking
        public void deleteTracking(Tracking tracking)
        {
            _context.Trackings.Remove(tracking);
            _context.SaveChanges();
        }

    }

}
