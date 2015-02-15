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
