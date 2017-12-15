using IRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Contracts
{
    public interface IContactInterestService
    {
        IEnumerable<ContactInterest> GetContactInterests();
        bool IsSelected();
    }
}
