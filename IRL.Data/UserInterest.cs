using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class UserInterest
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int InterestId { get; set; }

        public virtual Interest Interest { get; set; }
    }
}
