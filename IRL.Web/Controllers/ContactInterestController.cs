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
            var detail = new ContactDetail();
            var contactId = detail.ContactId;
            var svc = new ContactInterestService(userId, contactId);

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
            var contactModel = new Interest();
            var contact = new ContactDetail();
            contact.ContactId = contactId;
            var svc = CreateInterestService();
            contactModel.InterestId = interestId;
            svc.AddInterest();
            return View(contactModel);
        }
    }
}
