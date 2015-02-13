using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data.IDAO;

namespace ABCLogistics.Data.DAO
{

    public class TrackingDAO : ITrackingDAO
    {

        private ABCLogisticsDataEntities _context;

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
        // getTrackings
        public IList<Tracking> getTrackings()
        {
            IQueryable<Tracking> _trackings;
            _trackings = from tracking
                     in _context.Trackings
                         select tracking;
            return _trackings.ToList<Tracking>();
        }

        // getOrderTrackings
        public IList<Tracking> getOrderTrackings(int order)
        {
            IQueryable<Tracking> _trackings;
            _trackings = from tracking
                         in _context.Trackings
                         where tracking.FK_OrderID == order
                         select tracking;
            return _trackings.ToList<Tracking>();
        }

        // getTracking
        public Tracking getTracking(int id)
        {
            IQueryable<Tracking> _tracking;
            _tracking = from tracking
                     in _context.Trackings
                        where tracking.PK_TrackingID == id
                        select tracking;
            return _tracking.ToList<Tracking>().First();
        }

        // UPDATE ====================================================================
        // editTracking
        public void editTracking(Tracking tracking)
        {
            Tracking record = (from rec
                              in _context.Trackings
                               where rec.PK_TrackingID == tracking.PK_TrackingID
                               select rec).ToList<Tracking>().First();
            record.FK_OrderID = tracking.FK_OrderID;
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
