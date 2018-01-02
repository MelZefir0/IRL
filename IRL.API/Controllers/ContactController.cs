
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
        public IHttpActionResult Get()
        {
            ContactService contactService = CreateContactService();

            var contacts = contactService.GetContacts();

            return Ok(contacts);  
        }

        private ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contactService = new ContactService(userId);
            return contactService;
        }
    }
}
