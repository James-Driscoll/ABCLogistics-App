using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;

namespace ABCLogistics.Controllers
{

    [Authorize(Roles = "Staff, Admin")]
    public class TrackingAdminController : ApplicationController
    {
        
        // CONSTRUCTOR ==============================================================


        // CREATE ===================================================================


        // READ =====================================================================


        // UPDATE ===================================================================
        // Edit : Method for editting specific details about a tracking record.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Tracking record = _trackingService.getTracking(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Tracking tracking)
        {
            try
            {
                _trackingService.editTracking(tracking);
                return RedirectToAction("Parcels", "Order");
            }
            catch
            {
                return View();
            }
        }

        // DELETE ===================================================================
        // Delete : Method for delete a tracking record.
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Tracking tracking = _trackingService.getTracking(id);
            return View(tracking);
        }

        [HttpPost]
        public ActionResult Delete(Tracking tracking, int id)
        {
            try
            {
                Tracking _tracking = _trackingService.getTracking(id);
                _trackingService.deleteTracking(_tracking);
                return RedirectToAction("Parcels", "Order");
            }
            catch
            {
                return View();
            }
        }

    }

}
