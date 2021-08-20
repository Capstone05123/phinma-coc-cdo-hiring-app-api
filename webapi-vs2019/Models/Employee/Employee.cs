using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{

    public class Employee
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string AccountType { get; set; } // Employee, Employer
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ExperienceLevel { get; set; } // EntryLevel, Intermediate, Professional
        public string Description { get; set; }

    }
}