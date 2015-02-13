using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCLogistics.Data.IDAO
{

    interface ITrackingDAO
    {

        // CREATE ====================================================================
        // addTracking
        void addTracking(Tracking tracking);

        // READ ======================================================================
        // getTrackings
        IList<Tracking> getTrackings();

        // getOrderTrackings
        IList<Tracking> getOrderTrackings(int order);

        // getTracking
        Tracking getTracking(int id);

        // UPDATE ====================================================================
        // editTracking
        void editTracking(Tracking tracking);

        // DELETE ====================================================================
        // deleteTracking
        void deleteTracking(Tracking tracking);

    }

}
