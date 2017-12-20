using IRL.Contracts;
using IRL.Data;
using IRL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Services
{
    public class ContactService : IContactService
    {
        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }

        private Contact GetContactFromDatabase(ApplicationDbContext context, int contactId)
        {
            return
                context
                    .Contacts
                    .SingleOrDefault(e => e.ContactId == contactId && e.UserId == _userId);
        }

        public bool CreateContact(ContactCreate model)
        {
            var entity =
                new Contact()
                {
                    UserId = _userId,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Nickname = model.Nickname,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Notes = model.Notes,
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
                            ContactId = e.ContactId,
                            FirstName = e.FirstName,
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
                var contact =
                    ctx
                        .Contacts
                        .SingleOrDefault(e => e.ContactId == contactId);


                var contactInterests = new ContactInterestService(_userId, contactId);

            return
                new ContactDetail
                {
                    ContactId = contact.ContactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Nickname = contact.Nickname,
                    Address = contact.Address,
                    PhoneNumber = contact.PhoneNumber,
                    Notes = contact.Notes,
                    CreatedUtc = contact.CreatedUtc,
                    Interests = contactInterests.GetContactInterests(contactId)
                };
            }

        }


        public bool UpdateContact(ContactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetContactFromDatabase(ctx, model.ContactId);

                //var contactInterests = ContactInterestData;

                if (entity == null) return false;

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Nickname = model.Nickname;
                entity.Address = model.Address;  
                entity.PhoneNumber = model.PhoneNumber;
                entity.Notes = model.Notes;
                //entity.Interests = model.ContactInterestData Interests;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContact(int contactId)
        {
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Contacts
                            .Single(e => e.ContactId == contactId && e.UserId == _userId);

                    ctx.Contacts.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
}
