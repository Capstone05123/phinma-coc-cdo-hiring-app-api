using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string AccountType { get; set; } // Employee, Employer
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyName { get; set; }

        public bool IsVisible { get; set; }
        public int Reports { get; set; }
    }
}