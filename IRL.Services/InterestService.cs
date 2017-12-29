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
    public class InterestService
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

        private InterestEntity GetInterestsFromDatabase(ApplicationDbContext context, int interestId, string item)
        {
            return
                context
                    .Interests
                    .SingleOrDefault(
                           e => 
                           e.InterestId == interestId &&
                           e.Item == item);
        }

        private UserInterestEntity GetUserInterestsFromDatabase(ApplicationDbContext context, int interestId, Guid _userId)
        {
            return
                context
                    .UserInterests
                    .SingleOrDefault(
                           e =>
                           e.InterestId == interestId &&
                           e.UserId == _userId);
        }

        private ContactInterestEntity GetContactInterestsFromDatabase(ApplicationDbContext context, int interestId, int contactId)
        {
            return
                context
                    .ContactInterests
                    .SingleOrDefault(
                           e =>
                           e.InterestId == interestId &&
                           e.ContactId == contactId);
        }

        public ICollection<InterestListItem> GetInterests()
        {
            using (var ctx = new ApplicationDbContext())
            {
               return
                    ctx
                        .Interests
                        .Select(
                            e =>
                                new InterestListItem()
                                {
                                    InterestId = e.InterestId,
                                    Item = e.Item
                                })
                       .ToList();
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

        public ICollection<ContactInterestData> GetContactInterests(int contactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contactInterests =
                    ctx
                        .ContactInterests
                        .Where(i => i.ContactId == contactId)
                        .Select(
                            e =>
                                new ContactInterestData()
                                {
                                    InterestId = e.InterestId,
                                }
                        );
                return contactInterests.ToList();
            }
            
        }

        public void PopulateContactInterestData(ContactCreate contact)
        {
            var interestSvc = new InterestService().GetInterests();
            var contactInterests = new HashSet<int>(contact.Interests.Select(i => i.InterestId));
            var viewModel = new List<ContactInterestData>();
            //foreach (var interest in interestSvc)
            //{
            //    viewModel.Add(new ContactInterestData
            //    {
            //        InterestId = interest.InterestId,
            //        Item = interest.Interest,
            //        Chosen = contactInterests.Contains(interest.InterestId)
            //    });
            //}
            //ViewBag.Courses = viewModel;
        }


        public void UpdateContactInterests(string[] chosenInterests, ContactDetail model)
        {
            if (chosenInterests == null)
            {
                model.Interests = new List<InterestListItem>();
                return;
            }
            var chosenInterestsHS = new HashSet<string>(chosenInterests);
            var contactInterests = new HashSet<int>
                (model.Interests.Select(i => i.InterestId));
            foreach (var interest in model.Interests)
            {
                if (chosenInterestsHS.Contains(interest.Item.ToString()))
                {
                    if (!contactInterests.Contains(interest.InterestId))
                    {
                        model.Interests.Add(interest);
                    }
                }
                else
                {
                    if (contactInterests.Contains(interest.InterestId))
                    {
                        model.Interests.Remove(interest);
                    }
                }
            }
        }


        public bool AddInterest(UserInterestModel model)
        {
            //TODO: persist item from Interest 
            var entity =
                new UserInterestEntity()
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
