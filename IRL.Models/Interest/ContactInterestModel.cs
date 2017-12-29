using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class ContactInterestData
    {
        public int Id { get; set; }

        //public int ContactId { get; set; }

        public int InterestId { get; set; }

        public string Item { get; set; }

        public bool Chosen { get; set; }

    }
}
