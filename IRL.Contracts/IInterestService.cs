using IRL.Models;
using IRL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Contracts
{
    public interface IInterestService
    {
        ICollection<InterestListItem> GetInterests();
        InterestEntity GetInterestById(int id);
    }
}
