using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class ContactInterest
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public string InterestId { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
    }
}    
