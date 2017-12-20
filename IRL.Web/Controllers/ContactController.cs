using IRL.Data;
using IRL.Models;
using IRL.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        //private readonly Lazy<IContactService> _contactService;

        //public ContactController()
        //{                      
        //    _contactService = new Lazy<IContactService>(() =>
        //        new ContactService(Guid.Parse(User.Identity.GetUserId())));
        //}

        //public ContactController(Lazy<IContactService> contactService)
        //{
        //    _contactService = contactService;
        //}

        // GET: Contact

        private ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(userId);
            return service;
        }

        public ActionResult Index()
        {
            var service = CreateContactService();
            var model = service.GetContacts();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ContactCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateContactService();

            if (service.CreateContact(model))
            {
                TempData["SaveResult"] = "Contact Added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured. Please try again.");

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
                    Notes = contact.Notes,
                    //Interests = 
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactEdit model)
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