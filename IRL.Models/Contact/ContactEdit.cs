using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class ContactEdit
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public bool HasTalked { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }



        public virtual ICollection<InterestListItem> Interests { get; set; }
    }
}
