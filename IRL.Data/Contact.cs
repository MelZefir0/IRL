using IRL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public string Notes { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [DefaultValue(false)]
        public bool HasTalked { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
    }
}
