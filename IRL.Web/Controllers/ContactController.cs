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
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(userId);
            var model = service.GetContacts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
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

        private ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(userId);
            return service;
        }

        public ActionResult Details(int contactId)
        {
            var service = CreateContactService();
            var model = service.GetContactById(contactId);

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