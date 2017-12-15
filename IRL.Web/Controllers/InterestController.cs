using IRL.Models;
using IRL.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    public class InterestController : Controller
    {


        ////TODO: You need  something like this to get the specific user.
        //private InterestService CreateInterestService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var svc = new InterestService(userId);

        //    return svc;
        //}
        
        
        ////GET: Interest
        //public ActionResult Index()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new InterestService(userId);
        //    var model = CreateInterestService().GetInterests();
            
        //    return View(model);
        //}

        // GET: Interest
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InterestService(userId);
            var model = service.GetInterests();
            return View(model);
        }
    }
}
