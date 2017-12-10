using IRL.Models;
using IRL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Services
{
    public class InterestService /* : IInterestService*/
    {
       private readonly int interestId;

        public InterestService(int id)
        {
            interestId = id;
        }

        //public Interest GetInterestById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<InterestListItem> GetInterests()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsChecked(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<InterestDetail> GetInterests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interests
                        .Where(e => e.InterestId == interestId)
                        .Select(
                            e =>
                                new InterestDetail
                                {
                                    InterestId = e.InterestId,
                                    Item = e.Item,
                                    IsChecked = e.IsChecked
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
