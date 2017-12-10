using IRL.Models;
using IRL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Services
{
    interface IInterestService
    {
        IEnumerable<InterestListItem> GetInterests();
        Interest GetInterestById(int id);
        bool IsChecked(int id);
    }
}
