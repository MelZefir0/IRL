using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class Interest
    {
            [Key]
            public int InterestId { get; set; }

            [Required]
            public string Item { get; set; }
    }
}
