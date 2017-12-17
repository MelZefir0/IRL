using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IRL.Models
{
    public class UserInterestModel
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int InterestId { get; set; }

        public string Item { get; set; }

    }
}
