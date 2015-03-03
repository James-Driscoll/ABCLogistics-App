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

    public class AdminController : Controller
    {

        private ABCLogistics.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ========================================================
        public AdminController()
        {
            _context = new ABCLogistics.Models.ApplicationDbContext();
        }

        // CREATE =============================================================
        // CreateRole : Adds a new system role to the database.
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(
                    new IdentityRole() { Name = collection["RoleName"] });
                _context.SaveChanges();
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }

        // READ ===============================================================
        // ControlPanel : Returns view containing list of Admin related functions.
        public ActionResult ControlPanel()
        {
            return View();
        }
        
        // getUsers : NO VIEW YET
        public ActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        // RolesForUser : Returns list of roles associated with a particular user.
        [HttpGet]
        public ActionResult RolesForUser()
        {
            // populates user list for the view drop down menu.
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in _context.Users.ToList())
            {
                userList.Add(
                    new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName + " | " + item.UserName,
                        Value = item.UserName
                        //Selected = (item.UserName == (selectedUser) ? true : false)
                    });
            }
            ViewBag.userList = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RolesForUser(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new UserManager<ApplicationUser>( new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            }
            return View("RolesForUserConfirmed");
        }

        // UPDATE =============================================================
        // ManageUserRoles : Allows Admin to manage the roles associate with a particular user.
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            // populates roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            // populates users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string userName, string roleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, roleName);

            // prepopulat roles for the view dropdown
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            // populate users for the view dropdown
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            return View();
        }

    }

}
