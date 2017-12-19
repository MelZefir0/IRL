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
        public ActionResult Select(int? id, int newInterest)
        {
            var userModel = new UserInterestModel();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = CreateInterestService();
            var userInterest = svc.GetUserInterests(id);
            var existingId = userInterest.OfType<UserInterestModel>().FirstOrDefault();
            userModel.UserId = userId;
            userModel.InterestId = newInterest;
            //if (existingId == null)
            //{
            //    userModel.InterestId = newInterest;

            //    svc.AddInterest(userModel);
            //    return View(userModel);
            //}

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

        //[ActionName("Remove")]
        //public ActionResult Remove(int interestId, string item)
        //{
        //    var svc = CreateInterestService();
        //    var model = service.GetInterestById(interestId);

        //    svc.RemoveInterest(userModel);
        //    return View();
        //}


        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var service = CreateContactService();
        //    var model = service.GetContactById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateContactService();
        //    service.DeleteContact(id);

        //    TempData["SaveResult"] = "Contact deleted";


        //    return RedirectToAction("Index");
        //}
    }
}