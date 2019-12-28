using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHandler.Controllers
{
    public class DynamicReferencesController : Controller
    {
        // GET: DynamicReferences
        public ActionResult List()
        {
            return View("List");
        }
    }
}