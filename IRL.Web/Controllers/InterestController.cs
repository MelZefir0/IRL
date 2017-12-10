using IRL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        public ActionResult Index(int id)
        {
            var model = InterestService.GetInterests();
            return View(model);
        }
    }
}