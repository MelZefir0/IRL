using IRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Contracts
{
    public interface ISuggestionService
    {
        IEnumerable<ContactInterestModel> GetContactInterests();
        IEnumerable<UserInterestModel> GetUserInterests();
        bool GiveSuggestion(int contIntId, int userIntId);
    }
}
