using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;
using ABCLogistics.Services;
using ABCLogistics.Services.Service;

namespace ABCLogistics.Controllers
{
    public class CustomerController : Controller
    {

        // Declare local address service
        private AddressService _addressService;

        // Declare local item service
        private ItemService _itemService;

        // Declare a local tracking service.
        private TrackingService _trackingService;

        // Declare local order service.
        private OrderService _orderService;

        // Declare a local user service.
        private UserService _userService;

        public CustomerController()
        {
            _addressService = new AddressService();
            _itemService = new ItemService();
            _trackingService = new TrackingService();
            _orderService = new OrderService();
            _userService = new UserService();
        }

        // CREATE ===================================================================
        // addAddress
        [HttpGet]
        public ActionResult addAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addAddress(Address address)
        {
            View();
            _addressService.addAddress(address);
            return RedirectToAction("getAddresses", "Customer");
        }

        // READ =====================================================================
        // getAddresses
        public ActionResult getAddresses()
        {
            return View(_addressService.getAddresses());
        }

        // getAddress
        public ActionResult getAddress(int id)
        {
            return View(_addressService.getAddress(id));
        }

        // getItems
        public ActionResult getItems()
        {
            return View(_itemService.getItems());
        }

        // getItem
        public ActionResult getItem(int id)
        {
            return View(_itemService.getItem(id));
        }

        // getTrackings
        public ActionResult getTrackings()
        {
            return View(_trackingService.getTrackings());
        }

        // getOrderTrackings
        public ActionResult getOrderTrackings(int order)
        {
            return View(_trackingService.getOrderTrackings(order));
        }

        // getTracking
        public ActionResult getTracking(int id)
        {
            return View(_trackingService.getTracking(id));
        }

        // getOrders
        public ActionResult getOrders()
        {
            return View(_orderService.getOrders());
        }

        // getOrder
        public ActionResult getOrder(int id)
        {
            return View(_orderService.getOrder(id));
        }

        // getUser
        public ActionResult getUser(int id)
        {
            try
            {
                return View(_userService.getUser(id));
            }
            catch
            {
                return View();
            }
        }

        // UPDATE ===================================================================
        // editAddress
        [HttpGet]
        public ActionResult editAddress(int id)
        {
            Address record = _addressService.getAddress(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editAddress(Address address)
        {
            try
            {
                _addressService.editAddress(address);
                return RedirectToAction("getAddresses", "Customer");
            }
            catch
            {
                return View();
            }
        }


        // DELETE ===================================================================
        // deleteAddress
        [HttpGet]
        public ActionResult deleteAddress(int id)
        {
            Address address = _addressService.getAddress(id);
            return View(address);
        }

        [HttpPost]
        public ActionResult deleteAddress(Address address, int id)
        {
            try
            {
                Address _address = _addressService.getAddress(id);
                _addressService.deleteAddress(_address);
                return RedirectToAction("getAddresses", "Customer");
            }
            catch
            {
                return View();
            }
        }

    }
}