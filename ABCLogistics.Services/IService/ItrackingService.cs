using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCLogistics.Data;

namespace ABCLogistics.Services.IService
{

    interface ITrackingService
    {

        // CREATE ===================================================================
        // addTracking
        void addTracking(Tracking tracking);

        // READ =====================================================================
        // getTrackinges
        IList<Tracking> getTrackings();

        // getOrderTrackings : Returns IList of Tracking of a specific order.
        IList<Tracking> getOrderTrackings(int order);

        // getTracking
        Tracking getTracking(int id);

        // UPDATE ===================================================================
        // editTracking
        void editTracking(Tracking tracking);

        // DELETE ===================================================================
        // deleteTracking
        void deleteTracking(Tracking tracking);

    }
}
