using IRL.Models;
using IRL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRL.Contracts;

namespace IRL.Services
{
    public class ContactInterestService : IContactInterestService
    {
        private Guid _userId;

        public ContactInterestService(Guid UserId, int contactId)
        {
            _userId = UserId;
        }

        public IEnumerable<ContactInterestData> GetContactInterests()
        {
            throw new NotImplementedException();
        }

        public bool IsSelected()
        {
            throw new NotImplementedException();
        }

        private Interest GetInterestsFromDatabase(ApplicationDbContext context, int interestId, string item)
        {
            return
                context
                    .Interests
                    .SingleOrDefault(
                           e =>
                           e.InterestId == interestId &&
                           e.Item == item);
        }

        public ICollection<Interest> GetInterests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interests
                        .Select(
                            e =>
                                new Interest()
                                {
                                    InterestId = e.InterestId,
                                    Item = e.Item,
                                }
                        );
                return query.ToArray();
            }
        }

        public ICollection<Interest> GetContactInterests(int contactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contactInterests =
                    ctx
                        .ContactInterests
                        .Where(i => i.ContactId == contactId)
                        .Select(
                            e =>
                                new Interest()
                                {
                                    InterestId = e.InterestId,
                                }
                        );
                return contactInterests.ToList();
            }
        }


        public bool AddInterest()
        {
            //TODO: persist item from Interest 
            var model = new ContactInterestData();
            var entity =
                new ContactInterest()
                {
                    ContactId = model.Id,
                    InterestId = model.InterestId,
                    //Item = item.ToString()
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ContactInterests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
