﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Data
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}