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
        public ActionResult AddParcelTracking(Tracking tracking, int id)
        {
            View();
            tracking.Order = id;
            _trackingService.addTracking(tracking);
            return RedirectToAction("Index", "Staff");
        }

        // CreateParcel : Creates a new parcel.
        [HttpGet]
        public ActionResult CreateParcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            _parcelService.addParcel(orderBEAN);
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
            Branch _branch = _branchService.getBranch(record.Branch);

            ABCLogistics.Data.BEANS.OrderBEAN orderBEAN = new Data.BEANS.OrderBEAN()
            {
                Id = record.Id,
                Weight = record.Weight,
                Insured = record.Insured,
                DateOrdered = record.DateOrdered,
                DateDelivered = record.DateDelivered,
                Status = record.Status,
                Customer = record.Customer,
                BranchName = _branch.Name
            };

            return View(orderBEAN);
        }

        [HttpPost]
        public ActionResult EditParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN)
        {
            try
            {
                _parcelService.editParcel(orderBEAN);
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
            Parcel record = _parcelService.getParcel(id);
            Branch _branch = _branchService.getBranch(record.Branch);

            ABCLogistics.Data.BEANS.OrderBEAN orderBEAN = new Data.BEANS.OrderBEAN()
            {
                Id = record.Id,
                Weight = record.Weight,
                Insured = record.Insured,
                DateOrdered = record.DateOrdered,
                DateDelivered = record.DateDelivered,
                Status = record.Status,
                Customer = record.Customer,
                BranchName = _branch.Name
            };

            return View(orderBEAN);
        }

        [HttpPost]
        public ActionResult DeleteParcel(ABCLogistics.Data.BEANS.OrderBEAN orderBEAN, int id)
        {
            try
            {
                Parcel parcel = _parcelService.getParcel(id);
                Branch branch = _branchService.getBranch(parcel.Branch);
                orderBEAN.Id = parcel.Id;
                orderBEAN.Weight = parcel.Weight;
                orderBEAN.Insured = parcel.Insured;
                orderBEAN.DateOrdered = parcel.DateOrdered;
                orderBEAN.DateDelivered = parcel.DateDelivered;
                orderBEAN.Status = parcel.Status;
                orderBEAN.Customer = parcel.Customer;
                orderBEAN.BranchName = branch.Name;
                _parcelService.deleteParcel(orderBEAN);
               
                return RedirectToAction("Index", "Staff");
            }
            catch
            {
                return View();
            }
        }

    }

}
