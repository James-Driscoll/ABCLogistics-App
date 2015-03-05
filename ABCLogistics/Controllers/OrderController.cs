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
        public ActionResult AddParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = userManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            orderBEAN.Customer = currentUser.Id;
            _parcelService.addParcel(orderBEAN);
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
        public ActionResult Track(int id)
        {
            return View(_trackingService.getOrderTrackings(id));
        }

        // UPDATE ===================================================================
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
