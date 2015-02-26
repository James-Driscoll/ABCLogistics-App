using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;
using ABCLogistics.Services;
using ABCLogistics.Controllers;

namespace ABCLogistics.Controllers
{

    public abstract class ApplicationController : Controller
    {

        // Declare services
        public ABCLogistics.Services.Service.AddressService _addressService;
        public ABCLogistics.Services.Service.ItemService _itemService;
        public ABCLogistics.Services.Service.OrderService _orderService;
        public ABCLogistics.Services.Service.TrackingService _trackingService;
        public ABCLogistics.Services.Service.UserService _userService;

        // Declare dictionaries.
        //public Dictionary<int, string> _itemDictionary;
        //public Dictionary<int, string> _addressDictionary;
        //public Dictionary<int, string> _branchDictionary;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            _addressService = new ABCLogistics.Services.Service.AddressService();
            _itemService = new ABCLogistics.Services.Service.ItemService();
            _orderService = new ABCLogistics.Services.Service.OrderService();
            _trackingService = new ABCLogistics.Services.Service.TrackingService();
            _userService = new ABCLogistics.Services.Service.UserService();

            //ViewBag.Items = _itemService.getItems();

        }

    }

}
