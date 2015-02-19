using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ABCLogistics.Data;
using ABCLogistics.Services;
using ABCLogistics.Services.Service;
using ABCLogistics.Models;

namespace ABCLogistics.Controllers
{
    
    public class AdminController : ApplicationController
    {

        // Framework class for managing authorisation.
        private ABCLogistics.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ==============================================================
        public AdminController()
        {
            _context = new ABCLogistics.Models.ApplicationDbContext();
        }

        // CREATE ===================================================================
        // createRole
        [HttpGet]
        public ActionResult createRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(
                    new IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("getRoles");
            }
            catch
            {
                return View();
            }
        }
        
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
        // getRegisteredUsers
        public ActionResult getRegisteredUsers()
        {
            return View(_context.Users.ToList());
        }

        // getRolesForUser
        [HttpGet]
        public ActionResult getRolesForUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getRolesForUser(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(
                    userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new UserManager<ApplicationUser>(
                    new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("getRolesForUserConfirmed");
        }

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
