using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class Suggestion
    {
        public int Id { get; set; }

        public int InterestId { get; set; }

        public string SuggestionItem { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
    }
}
