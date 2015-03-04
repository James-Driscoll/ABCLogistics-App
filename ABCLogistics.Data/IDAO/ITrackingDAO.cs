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

        // getOrderTrackings : Returns IList of Tracking of a specific order.
        IList<Tracking> getOrderTrackings(int id);

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
