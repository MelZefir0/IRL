﻿using IRL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRL.Models;
using IRL.Data;

namespace IRL.Services
{
    public class SuggestionService : ISuggestionService
    {
        public IEnumerable<ContactInterestData> GetContactInterests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInterestModel> GetUserInterests()
        {
            throw new NotImplementedException();
        }

        public bool GiveSuggestion(int contIntId, int userIntId)
        {
            throw new NotImplementedException();
        }
    }
}
