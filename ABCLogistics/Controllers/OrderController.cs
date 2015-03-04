using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ABCLogistics.Models;

namespace ABCLogistics.Controllers
{

    public class OrderController : ApplicationController
    {

        // CREATE ===================================================================
        // AddParcel
        [HttpGet] [Authorize(Roles="Customer")]
        public ActionResult AddParcel()
        {

            return View();
        }

        [HttpPost] [Authorize(Roles="Customer")]
        public ActionResult AddParcel(Parcel parcel)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            parcel.Customer = currentUser.Id;
            _parcelService.addParcel(parcel);
            return RedirectToAction("Parcels", "Order");
        }

        // AddTracking
        [HttpGet] [Authorize(Roles="Customer")]
        public ActionResult AddTracking(int id)
        {
            return View();
        }

        [HttpPost] [Authorize(Roles="Customer")]
        public ActionResult AddTracking(Tracking tracking)
        {
            View();
            _trackingService.addTracking(tracking);
            return RedirectToAction("Parcels", "Order");
        }

        // READ =====================================================================
        // Parcels
        [HttpGet] [Authorize(Roles="Customer")]
        public ActionResult Parcels()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            var currentUserID = currentUser.Id;
            var customer = currentUserID;
            return View(_parcelService.getCustomerParcels(customer));
        }
       
        // Track : Returns IList of Tracking of a specific order. (getOrderTrackings)
        [Authorize(Roles="Customer")]
        public ActionResult Track(int order)
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
        public ActionResult DeleteParcel(int id)
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
