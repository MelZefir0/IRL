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

        public IEnumerable<ContactListItem> GetContacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx
                        .Contacts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                            new ContactListItem
                            {
                                ContactId = e.ContactId,
                                FirstName = e.FirstName,
                                CreatedUTC = e.CreatedUtc,
                                HasTalked = e.HasTalked
                            })
                    .ToArray();
            }
        }

        public bool CreateContact(ContactCreate model)
        {
            //var interestService = new InterestService();

            var entity =
                new Contact()
                {
                    UserId = _userId,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    Nickname = model.Nickname,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Birthday = model.Birthday,
                    Notes = model.Notes,
                    CreatedUtc = DateTime.Now,
                    //Interests = interestService.GetInterests();
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ContactDetail GetContactById(int contactId)
        {
            Contact entity;

            using (var ctx = new ApplicationDbContext())
            {
               entity = GetContactFromDatabase(ctx, contactId);
            }

            if (entity == null) return new ContactDetail();
 ;
            //var interestService = new InterestService();

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
                    CreatedUtc = entity.CreatedUtc,
                    //Interests = interestService.GetInterests()
                    //Interests = interestService.GetContactInterests(contactId)
               };

        }

        public bool UpdateContact(ContactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            { 

                var contactId = model.ContactId;
                var entity = GetContactFromDatabase(ctx, contactId);
                //var contactInterests = new InterestService().GetContactInterests(contactId);

                if (entity == null) return false;

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Nickname = model.Nickname;
                entity.Address = model.Address;  
                entity.PhoneNumber = model.PhoneNumber;
                entity.Notes = model.Notes;
                entity.HasTalked = model.HasTalked;

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
