using IRL.Contracts;
using IRL.Data;
using IRL.Models;
using IRL.Services;
using IRL.ViewModels;
using IRL.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly Lazy<IContactService> _contactService;

        public ContactController()
        {                      
            _contactService = new Lazy<IContactService>(() =>
                new ContactService(Guid.Parse(User.Identity.GetUserId())));
        }

        public ContactController(Lazy<IContactService> contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        private Guid _userId;

        private Contact contact = new Contact();

        private ContactService CreateContactService()
        {
            var _userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(_userId);
            //var interestService = new InterestService().GetInterests();
            return service;
        }
        //Attention
        public void PopulateContactInterestData()
        {
            var interestSvc = new InterestService();
            var allInterests = interestSvc.GetInterests();
            var contactInterests = new HashSet<int>(contact.Interests.Select(i => i.InterestId));
            var viewModel = new List<ViewModels.ContactInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new ViewModels.ContactInterestData
                {
                    InterestId = interest.InterestId,
                    Interest = interest.Item,
                    Chosen = contactInterests.Contains(interest.InterestId)
                });
            }
            ViewBag.Courses = viewModel;
        }



        public ActionResult Index()
        {
            var service = CreateContactService();
            var model = service.GetContacts();
            return View(model);
        }

        public ActionResult Create()
        {
            //var model = new ContactCreate();
            //return View(model);
            //TODO
            var model = new ContactCreate();
            //model.Interests = new List<InterestListItem>();
            //PopulateContactInterestData();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreate model, string[] chosenInterests)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateContactService();

            if (chosenInterests != null)
            {
                model.Interests = new List<InterestListItem>();
                foreach (var interest in chosenInterests)
                {
                    var interestToAdd = model.Interests.FirstOrDefault(i => i.Item == interest);
                    model.Interests.Add(interestToAdd);
                }
            }

            if (service.CreateContact(model))
            {
                TempData["SaveResult"] = "Contact Added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured. Please try again.");

            //PopulateContactInterestData();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateContactService();
            var contact = service.GetContactById(id);

            var model =
                new ContactEdit
                {
                    ContactId = contact.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Nickname = contact.Nickname,
                    Address = contact.Address,
                    PhoneNumber = contact.PhoneNumber,
                    Birthday = contact.Birthday,
                    Notes = contact.Notes,
                };
            //PopulateContactInterestData();
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ContactEdit model, string[] chosenInterests)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ContactId != id)
            {
                ModelState.AddModelError("", "Error");
                return View(model);
            }

            var service = CreateContactService();

            if (service.UpdateContact(model))
            {
                TempData["SaveResult"] = "Contact updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not be updated.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateContactService();
            var model = service.GetContactById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateContactService();
            var model = service.GetContactById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateContactService();
            service.DeleteContact(id);

            TempData["SaveResult"] = "Contact deleted";


            return RedirectToAction("Index");
        }
    }
}