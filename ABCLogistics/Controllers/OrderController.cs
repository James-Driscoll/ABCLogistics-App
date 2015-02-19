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
        // addItem
        [HttpGet]
        public ActionResult addItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addItem(Item item)
        {
            View();
            _itemService.addItem(item);
            return RedirectToAction("getItems", "Customer");
        }

        // addTracking
        [HttpGet]
        public ActionResult addTracking(int FK_OrderID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult addTracking(Tracking tracking)
        {
            View();
            _trackingService.addTracking(tracking);
            return RedirectToAction("getOrders", "Customer");
        }

        // addOrder
        [HttpGet]
        public ActionResult addOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addOrder(Order order)
        {
            View();
            _orderService.addOrder(order);
            return RedirectToAction("getOrders", "Customer");
        }

        // READ =====================================================================


        // UPDATE ===================================================================
        // editItem
        [HttpGet]
        public ActionResult editItem(int id)
        {
            Item record = _itemService.getItem(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editItem(Item item)
        {
            try
            {
                _itemService.editItem(item);
                return RedirectToAction("getItems", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // editTracking
        [HttpGet]
        public ActionResult editTracking(int id)
        {
            Tracking record = _trackingService.getTracking(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editTracking(Tracking tracking)
        {
            try
            {
                _trackingService.editTracking(tracking);
                return RedirectToAction("getTrackings", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // editOrder
        [HttpGet]
        public ActionResult editOrder(int id)
        {
            Order order = _orderService.getOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult editOrder(Order order)
        {
            try
            {
                _orderService.editOrder(order);
                return RedirectToAction("getOrders", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // DELETE ===================================================================
        // deleteItem
        [HttpGet]
        public ActionResult deleteItem(int id)
        {
            Item item = _itemService.getItem(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult deleteItem(Item item, int id)
        {
            try
            {
                Item _item = _itemService.getItem(id);
                _itemService.deleteItem(_item);
                return RedirectToAction("getItems", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // deleteTracking
        [HttpGet]
        public ActionResult deleteTracking(int id)
        {
            Tracking tracking = _trackingService.getTracking(id);
            return View(tracking);
        }

        [HttpPost]
        public ActionResult deleteTracking(Tracking tracking, int id)
        {
            try
            {
                Tracking _tracking = _trackingService.getTracking(id);
                _trackingService.deleteTracking(_tracking);
                return RedirectToAction("getTrackings", "Customer");
            }
            catch
            {
                return View();
            }
        }

        // deleteOrder
        [HttpGet]
        public ActionResult deleteOrder(int id)
        {
            Order order = _orderService.getOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult deleteOrder(Order order, int id)
        {
            try
            {
                Order _order = _orderService.getOrder(id);
                _orderService.deleteOrder(_order);
                return RedirectToAction("getOrders", "Customer");
            }
            catch
            {
                return View();
            }
        }

    }
}
