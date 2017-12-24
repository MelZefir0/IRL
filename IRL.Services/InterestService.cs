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
    public class InterestService /*: /*IInterestService*/
    {
        private readonly Guid _userId;
        private readonly int _contactId;

        public InterestService(Guid UserId)
        {
            _userId = UserId;
        }

        public InterestService()
        {
        }

        public InterestService(int contactId)
        {
            _contactId = contactId;
        }

        private Data.Interest GetInterestsFromDatabase(ApplicationDbContext context, int interestId, string item)
        {
            return
                context
                    .Interests
                    .SingleOrDefault(
                           e => 
                           e.InterestId == interestId &&
                           e.Item == item);
        }

        private UserInterest GetUserInterestsFromDatabase(ApplicationDbContext context, int interestId, Guid _userId)
        {
            return
                context
                    .UserInterests
                    .SingleOrDefault(
                           e =>
                           e.InterestId == interestId &&
                           e.UserId == _userId);
        }

        public ICollection<InterestListItem> GetInterests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interests
                        .Select(
                            e =>
                                new InterestListItem()
                                {
                                    InterestId = e.InterestId,
                                    Item = e.Item,
                                }
                        );
                return query.ToList();
            }
        }

        public ICollection<UserInterestModel> GetUserInterests(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserInterests
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new UserInterestModel()
                                {
                                    UserId = _userId,
                                    InterestId = e.InterestId,
                                }
                        );
                return query.ToList();
            }
        }

        public ICollection<ContactInterest> GetContactInterests(int contactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contactInterests =
                    ctx
                        .ContactInterests
                        .Where(i => i.ContactId == contactId)
                        .Select(
                            e =>
                                new ContactInterest()
                                {
                                    InterestId = e.InterestId,
                                }
                        );
                return contactInterests.ToList();
            }
        }

        public bool AddInterest(UserInterestModel model)
        {
            //TODO: persist item from Interest 
            var entity =
                new UserInterest()
                {
                    UserId = _userId,
                    InterestId = model.InterestId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserInterests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveInterest(int interestId)
        {
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .UserInterests
                            .Single(e => e.InterestId == interestId && e.UserId == _userId);

                    ctx.UserInterests.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
}
