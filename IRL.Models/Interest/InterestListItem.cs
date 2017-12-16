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

        [UIHint("Starred")]
        public bool IsSelected { get; set; }
    }
}
