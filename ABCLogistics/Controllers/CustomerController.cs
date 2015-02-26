using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABCLogistics.Data;

namespace ABCLogistics.Controllers
{
    
    public class CustomerController : ApplicationController
    {

        // CREATE ===================================================================


        // READ =====================================================================
        // UserProfile
        public ActionResult UserProfile(int id)
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


        // DELETE ===================================================================


    }

}
