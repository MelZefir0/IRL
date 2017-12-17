using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Models
{
    /// <summary>
    /// May not need
    /// </summary>
    public class InterestDetail
    {
        [Key]
        public int InterestId { get; set; }

        public string Item { get; set; }
    }
}
