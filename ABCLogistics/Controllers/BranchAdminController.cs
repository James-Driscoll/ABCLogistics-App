using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;

namespace ABCLogistics.Controllers
{

    [Authorize(Roles = "Admin")]
    public class BranchAdminController : ApplicationController
    {

        // CREATE ===================================================================
        // Create : Adds new Branch.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            View();
            _branchService.addBranch(branch);
            return RedirectToAction("Index", "BranchAdmin");
        }

        // READ =====================================================================
        // Index : Returns IList of all Branches.
        public ActionResult Index()
        {
            return View(_branchService.getBranches());
        }

        // Details : Returns one Branch.
        public ActionResult Details(int id)
        {
            return View(_branchService.getBranch(id));
        }

        // UPDATE ===================================================================
        // Edit : Allows for updateding one Branch.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Branch record = _branchService.getBranch(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            try
            {
                _branchService.editBranch(branch);
                return RedirectToAction("Index", "BranchAdmin");
            }
            catch {
                return View();
            }
        }
        
        // DELETE ===================================================================
        // Delete : Removes a single Branch.
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Branch record = _branchService.getBranch(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult Delete(Branch branch, int id)
        {
            try
            {
                Branch _branch = _branchService.getBranch(id);
                _branchService.deleteBranch(_branch);
                return RedirectToAction("Index", "BranchAdmin");
            }
            catch
            {
                return View();
            }
        }

    }

}
