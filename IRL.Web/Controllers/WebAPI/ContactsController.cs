using IRL.Models;
using IRL.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IRL.Web.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Contacts")]
    public class ContactsController : ApiController
    {
        private bool SetStarState(int contactId, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(userId);

            var detail = service.GetContactById(contactId);

            var updatedContact =
                new ContactEdit
                {
                    ContactId = detail.ContactId,

                    HasTalked = newState

                };

            return service.UpdateContact(updatedContact);
        }

        [Route("{contactid}/Star")]
        public bool Put(int id)
        {
            return SetStarState(id, true);
        }

        [Route("{contactid}/Star")]
        public bool Delete(int id)
        {
            return SetStarState(id, false);
        }
    }
}
