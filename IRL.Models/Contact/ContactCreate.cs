using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class ContactCreate
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string Nickname { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(8000)]
        public string Notes { get; set; }

        public virtual ICollection<InterestListItem> Interests { get; set; }
    }
}
