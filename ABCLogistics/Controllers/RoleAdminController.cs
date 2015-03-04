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
    
    public class RoleAdminController : Controller
    {

        private ABCLogistics.Models.ApplicationDbContext _context;

        // CONSTRUCTOR ========================================================
        public RoleAdminController()
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // READ ===============================================================
        // Roles : Returns list of system roles.
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // DELETE =============================================================
        // DeleteRole : Deletes a system role from the database.
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }

}
