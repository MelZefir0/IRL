using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRL.Web.Models
{
    public class ContactInterestData
    {
        public int InterestId { get; set; }
        public string Interest { get; set; }
        public bool Chosen { get; set; }
    }
}
