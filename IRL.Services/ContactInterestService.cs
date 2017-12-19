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
    public class ContactInterestService /*: IContactInterestService*/
    {
        private Guid _userId;

        public ContactInterestService(Guid UserId)
        {
            _userId = UserId;
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
                return query.ToArray();
            }
        }

        public ContactInterestDetail GetContactInterestById(int interestId, string item)
        {
            Interest entity;

            using (var ctx = new ApplicationDbContext())
            {
                entity = GetInterestsFromDatabase(ctx, interestId, item);
            }

            //if (entity == null) return new Interest();

            return
                new ContactInterestDetail
                {
                    InterestId = entity.InterestId,
                    Item = entity.Item,
                };
        }


        public bool AddInterest()
        {
            //TODO: persist item from Interest 
            var model = new ContactInterestModel();
            var entity =
                new ContactInterest()
                {
                    ContactId = model.ContactId,
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
