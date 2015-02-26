using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;

namespace ABCLogistics.Controllers
{
    public class OrderController : ApplicationController
    {

        // CREATE ===================================================================
        // AddParcel
        [HttpGet]
        public ActionResult AddParcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddParcel(Parcel parcel)
        {
            View();
            _parcelService.addParcel(parcel);
            return RedirectToAction("Parcels", "Order");
        }

        // AddTracking
        [HttpGet]
        public ActionResult AddTracking(int order)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTracking(Tracking tracking)
        {
            View();
            _trackingService.addTracking(tracking);
            return RedirectToAction("Parcels", "Order");
        }

        // READ =====================================================================
        // Parcels
        public ActionResult Parcels()
        {
            return View(_parcelService.getParcels());
        }

        // Parcel
        public ActionResult Parcel(int id)
        {
            return View(_parcelService.getParcel(id));
        }

        // Trackings
        public ActionResult Trackings(int order)
        {
            return View(_trackingService.getOrderTrackings(order));
        }

        // UPDATE ===================================================================
        // EditParcel
        [HttpGet]
        public ActionResult EditParcel(int id)
        {
            Parcel record = _parcelService.getParcel(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult EditParcel(Parcel parcel)
        {
            try
            {
                _parcelService.editParcel(parcel);
                return RedirectToAction("Parcels", "Order");
            }
            catch
            {
                return View();
            }
        }

        // EditTracking
        [HttpGet]
        public ActionResult EditTracking(int id)
        {
            Tracking record = _trackingService.getTracking(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult EditTracking(Tracking tracking)
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
        // DeleteParcel
        [HttpGet]
        public ActionResult AeleteParcel(int id)
        {
            Parcel parcel = _parcelService.getParcel(id);
            return View(parcel);
        }

        [HttpPost]
        public ActionResult DeleteParcel(Parcel parcel, int id)
        {
            try
            {
                Parcel _parcel = _parcelService.getParcel(id);
                _parcelService.deleteParcel(_parcel);
                return RedirectToAction("Parcels", "Order");
            }
            catch
            {
                return View();
            }
        }

        // DeleteTracking
        [HttpGet]
        public ActionResult DeleteTracking(int id)
        {
            Tracking tracking = _trackingService.getTracking(id);
            return View(tracking);
        }

        [HttpPost]
        public ActionResult DeleteTracking(Tracking tracking, int id)
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
