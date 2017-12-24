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
        IEnumerable<Interest> GetContactInterests();
        IEnumerable<UserInterestModel> GetUserInterests();
        bool GiveSuggestion(int contIntId, int userIntId);
    }
}
