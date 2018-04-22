using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeTestingApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult DeleteUser()
        {
            return View();
        }
    }
}