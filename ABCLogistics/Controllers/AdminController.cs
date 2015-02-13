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
    public class AdminController : Controller
    {

        // Declare a local user service.
        private UserService _userService;

        public AdminController()
        {
            _userService = new UserService();
        }

        // CREATE ===================================================================
        // addUser
        [HttpGet]
        public ActionResult addUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addUser(User user)
        {
            View();
            _userService.addUser(user);
            return RedirectToAction("getUsers", "Admin");
        }

        // READ =====================================================================
        // getUsers
        public ActionResult getUsers()
        {
            return View(_userService.getUsers());
        }

        // UPDATE ===================================================================
        // editUser
        [HttpGet]
        public ActionResult editUser(int id)
        {
            User record = _userService.getUser(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editUser(User user)
        {
            try
            {
                _userService.editUser(user);
                return RedirectToAction("getUsers", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // DELETE ===================================================================
        // deleteUser
        [HttpGet]
        public ActionResult deleteUser(int id)
        {
            User user = _userService.getUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult deleteUser(User user, int id)
        {
            try
            {
                User _user = _userService.getUser(id);
                _userService.deleteUser(_user);
                return RedirectToAction("getUsers", "Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}