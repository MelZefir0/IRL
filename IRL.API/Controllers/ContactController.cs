
using IRL.Models;
using IRL.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IRL.API.Controllers
{
    [Authorize]
    public class ContactController : ApiController
    {
        //GET /api/contact
        public IHttpActionResult GetAll()
        {
            ContactService contactService = CreateContactService();

            var contacts = contactService.GetContacts();

            return Ok(contacts);  
        }

        //Get /api/note/5
        public IHttpActionResult Get(int id)
        {
            ContactService contactService = CreateContactService();

            var contact = contactService.GetContactById(id);

            return Ok(contact);
        }

        public IHttpActionResult Post(ContactCreate contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContactService();

            if (!service.CreateContact(contact))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ContactEdit contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContactService();

            if (!service.UpdateContact(contact))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateContactService();

            if (!service.DeleteContact(id))
                return InternalServerError();

            return Ok();
        }

        private ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contactService = new ContactService(userId);
            return contactService;
        }
    }
}
