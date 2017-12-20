using IRL.Models;
using IRL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    public class InterestController : Controller
    {
        private InterestService CreateInterestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new InterestService(userId);

            return svc;
        }

        //GET: Interest
        public ActionResult Index()
        {
            var model = CreateInterestService().GetInterests();
            return View(model);
        }

        [ActionName("Select")]
        public ActionResult Select(int interestId, int? id)
        {
            var userModel = new UserInterestModel();
            var userId = Guid.Parse(User.Identity.GetUserId());
            userModel.UserId = userId;
            userModel.InterestId = interestId;
            var svc = CreateInterestService();
        
            svc.AddInterest(userModel);
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Select(UserInterestModel userModel)
        {
            if (!ModelState.IsValid) return View(userModel);

            var service = CreateInterestService();

            if (service.AddInterest(userModel))
            {
                TempData["SaveResult"] = "Your interest preference has been stored";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured. Please try again.");

            return RedirectToAction("Index");
        }
    }
}