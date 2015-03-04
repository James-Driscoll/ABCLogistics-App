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
        
        // Users : Retunrns list of users.
        public ActionResult Users()
        {
            return View(_context.Users.ToList());
        }

        // Roles : Returns list of system roles.
        public ActionResult Roles()
        {
            return View(_context.Roles.ToList());
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
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);
            }
            return View("RolesForUserConfirmed");
        }

        // UPDATE =============================================================
        // EditRole : Edits the name of an existing system role.
        [HttpGet]
        public ActionResult EditRole(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var role = roleManager.FindById(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult EditRole(IdentityRole role)
        {
            try
            {
                _context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }
        
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
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            userManager.AddToRole(user.Id, RoleName);

            // prepopulat roles for the view dropdown
            //var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            //ViewBag.Roles = roleList;

            // populate users for the view dropdown
            //var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            //ViewBag.Users = userList;

            //return View();

            return RedirectToAction("ControlPanel");
        }

        // DELETE =============================================================
        [HttpGet]
        public ActionResult DeleteRole(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var role = roleManager.FindById(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult DeleteRole(IdentityRole role, string id)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
                var _role = roleManager.FindById(id);
                roleManager.Delete(_role);
                return RedirectToAction("Roles");
            }
            catch
            {
                return View();
            }
        }

    }

}
