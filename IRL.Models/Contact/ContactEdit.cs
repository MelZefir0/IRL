﻿using System;
using System.Collections.Generic;
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
    }
}