using IRL.Data;
using IRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Services
{
    public class ContactService
    {
        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContact(ContactCreate model)
        {
            var entity =
                new Contact()
                {
                    UserId = _userId,
                    LastName = model. LastName,
                    FirstName = model.FirstName,
                    CreatedUtc = DateTime.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }  
        }

        public IEnumerable<ContactListItem> GetContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Contacts
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new ContactListItem
                        {
                            Name = e.FirstName,
                            CreatedUTC = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }

        public ContactDetail GetContactById(int contactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contacts
                        .SingleOrDefault(e => e.ContactId == contactId && e.UserId == _userId);
                return
                    new ContactDetail
                    {
                        ContactId = entity.ContactId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Nickname = entity.Nickname,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                        Notes = entity.Notes,
                        CreatedUtc = entity.CreatedUtc

                    };
            }
        }
    }
}
