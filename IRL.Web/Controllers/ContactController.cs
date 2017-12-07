using IRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRL.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactListItem[0];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}