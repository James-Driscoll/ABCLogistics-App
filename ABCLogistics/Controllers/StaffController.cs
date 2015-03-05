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
    
    //[Authorize(Roles="Staff")]
    public class StaffController : ApplicationController
    {

        // Framework class for managing authorisation.
        private ABCLogistics.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public StaffController()
        {
            _context = new ABCLogistics.Models.ApplicationDbContext();
        }
        
        // CREATE ===================================================================
        // AddParcelTracking : Adds tracking details about a specific parcel.
        [HttpGet]
        public ActionResult AddParcelTracking(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddParcelTracking(Tracking tracking)
        {
            View();
            _trackingService.addTracking(tracking);
            return RedirectToAction("Index", "Staff");
        }

        // CreateParcel : Creates a new parcel.
        [HttpGet]
        public ActionResult CreateParcel()
        {
            // populates user list for the view drop down menu.
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.Users.ToList())
            {
                userList.Add(
                    new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName + " | " + item.UserName,
                        Value = item.Id.ToString()
                        //Selected = (item.UserName == (selectedUser) ? true : false)
                    });
            }
            ViewBag.userList = userList;
            return View();
        }

        [HttpPost]
        public ActionResult CreateParcel(Parcel parcel)
        {
            _parcelService.addParcel(parcel);
            return RedirectToAction("Index");
        }

        // READ =====================================================================
        // Index : Lists details of all parcels.
        public ActionResult Index()
        {
            return View(_parcelService.getParcels());
        }

        // CustomerDetails : Returns details about one specific customer profile.
        public ActionResult CustomerDetails(string customer)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var user = userManager.FindById(customer);
            return View(user);
        }

        // TrackOrder : Returns IList of Tracking records of a specific order. (getOrderTrackings)
        public ActionResult TrackOrder(int id)
        {
            return View(_trackingService.getOrderTrackings(id));
        }

        // UPDATE ===================================================================
        // EditParcel : Method for editting the details of a particular parcel.
        [HttpGet]
        public ActionResult EditParcel(int id)
        {
            // populates user list for the view drop down menu.
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.Users.ToList())
            {
                userList.Add(
                    new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName + " | " + item.UserName,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.userList = userList;
            Parcel record = _parcelService.getParcel(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult EditParcel(Parcel parcel)
        {
            try
            {
                _parcelService.editParcel(parcel);
                return RedirectToAction("Index", "Staff");
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
                return RedirectToAction("Index", "Staff");
            }
            catch
            {
                return View();
            }
        }

    }

}
