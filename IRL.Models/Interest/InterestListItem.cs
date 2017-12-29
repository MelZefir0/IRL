using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class InterestListItem
    {
        [Key]
        public int InterestId { get; set; }

        public string Item { get; set; }

        public bool Chosen { get; set; }

        //public virtual ICollection<Contact> Contacts { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
