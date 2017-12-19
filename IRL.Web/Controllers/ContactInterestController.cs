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
    public class ContactInterestController : InterestController
    {
       private ContactInterestService CreateInterestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ContactInterestService(userId);

            return svc;
        }

        //GET: Interest
        public new ActionResult Index()
        {
            var model = CreateInterestService().GetInterests();
            return View(model);
        }

        [ActionName("Select")]
        public ActionResult Select(int interestId, int contactId)
        {
            var contactModel = new ContactInterestModel();
            var contact = new ContactDetail();
            contact.ContactId = contactId;
            var svc = CreateInterestService();
            contactModel.InterestId = interestId;
            svc.AddInterest();
            return View(contactModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Select(ContactInterestModel contactModel)
        //{
        //    if (!ModelState.IsValid) return View(contactModel);
            //    var service = CreateInterestService();

        //    if (service.AddInterest(contactModel))
        //    {
        //        TempData["SaveResult"] = "Your interest preference has been stored";
        //        return RedirectToAction("Index");
        //    }
            //    ModelState.AddModelError("", "An error occured. Please try again.");

        //    return RedirectToAction("Index");
        //}
    }
}
