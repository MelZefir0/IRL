using IRL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRL.Models;
using IRL.Data;

namespace IRL.Services
{
    //public class UserInterestService /*: IUserInterestService*/ : InterestService
    //{
    //    private Guid _userId;

    //    public UserInterestService(Guid UserId) : base(UserId)
    //    {
    //        _userId = UserId;
    //    }

    //    //This is saving 
    //    public bool StoreUserInterests(InterestUser model)
    //    {
    //        var entity =
    //                  new UserInterest()
    //                  {
    //                      UserId = _userId,
    //                      Id = model.Id,
    //                      InterestId = model.InterestId
    //                  };

    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            ctx.UserInterests.Add(entity);
    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
    //}
}
