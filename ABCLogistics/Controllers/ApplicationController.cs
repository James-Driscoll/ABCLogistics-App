using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;
using ABCLogistics.Services;
using ABCLogistics.Controllers;
using ABCLogistics.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ABCLogistics.Controllers
{

    public abstract class ApplicationController : Controller
    {

        // Declare services
        public ABCLogistics.Services.Service.ParcelService _parcelService;
        public ABCLogistics.Services.Service.TrackingService _trackingService;
        public ABCLogistics.Services.Service.UserService _userService;
        public ABCLogistics.Services.Service.BranchService _branchService;

        // Declare dictionaries.
        //public Dictionary<int, string> _branchDictionary;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            // Construct services.
            _parcelService = new ABCLogistics.Services.Service.ParcelService();
            _trackingService = new ABCLogistics.Services.Service.TrackingService();
            _userService = new ABCLogistics.Services.Service.UserService();
            _branchService = new ABCLogistics.Services.Service.BranchService();

            // Construct list of Tracking statuses.
            var trackingStatuses = new SelectList(new[] 
            {
                new { ID = "Processing", Name = "Processing" },
                new { ID = "Dispatched", Name = "Dispatched" },
                new { ID = "Being Shipped", Name = "Being Shipped" },
                new { ID = "Shipped", Name = "Shipped" },
                new { ID = "Dispatched", Name = "Dispatched" },
                new { ID = "Delivered", Name = "Delivered" },
                new { ID = "Complete", Name = "Complete" },
                new { ID = "Cancelled", Name = "Cancelled" }
            },
            "ID", "Name", 1);
            ViewData["trackingStatuses"] = trackingStatuses;

            // Construct list of Order statuses.
            var orderStatuses = new SelectList(new[] 
            {
                new { ID = "Received", Name = "Received" },
                new { ID = "Processing", Name = "Processing" },
                new { ID = "Complete", Name = "Complete" }
            },
            "ID", "Name", 1);
            ViewData["orderStatuses"] = orderStatuses;

            // Construct list of Branch names.
            List<SelectListItem> branchList = new List<SelectListItem>();
            foreach (var item in _branchService.getBranches())
            {
                branchList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.Name
                    });
            }
            ViewBag.branchList = branchList;

        }

    }

}
