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

        // Declare dictionaries.
        //public Dictionary<int, string> _itemDictionary;
        //public Dictionary<int, string> _addressDictionary;
        //public Dictionary<int, string> _branchDictionary;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            _parcelService = new ABCLogistics.Services.Service.ParcelService();
            _trackingService = new ABCLogistics.Services.Service.TrackingService();
            _userService = new ABCLogistics.Services.Service.UserService();

            //ViewBag.Items = _itemService.getItems();
        }

    }

}
