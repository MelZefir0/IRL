using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class UserInterest
    {
        
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string InterestId { get; set; }
    }
}
