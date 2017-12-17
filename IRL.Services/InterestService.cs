﻿using IRL.Models;
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
        private Guid _userId;

        public InterestService(Guid UserId)
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

        //public InterestDetail GetInterestById(int interestId)
        //{
        //    Interest entity;

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        entity = GetInterestsFromDatabase(ctx, interestId);
        //    }

        //    //if (entity == null) return new Interest();

        //    return
        //        new InterestDetail
        //        {
        //            InterestId = entity.InterestId,
        //            Item = entity.Item,
        //        };
        //}

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

        public bool AddInterest(UserInterestModel model /*Interest item*/)
        {
            //TODO: persist item from Interest 
            var entity =
                new UserInterest()
                {
                    UserId = _userId,
                    InterestId = model.InterestId,
                    //Item = item.ToString()
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserInterests.Add(entity);
                return ctx.SaveChanges() == 1;
            }

            //using (var ctx = new ApplicationDbContext())
            //{

            //    var entity =
            //        ctx
            //            .UserInterests
            //            .Single(e => e.InterestId == interestId && e.UserId == _userId && e.Item == item);
            //    ctx.UserInterests.Add(entity);
            //    return ctx.SaveChanges() == 1;

            //}
        }
    }
}
