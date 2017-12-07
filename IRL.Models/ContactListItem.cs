using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    public class ContactListItem
    {
        //public int ContactId { get; set; }
        public string Name { get; set; }

        [Display(Name="Added")]
        public DateTimeOffset CreatedUTC { get; set; }

        public override string ToString() => Name;
    }
}
