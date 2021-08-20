using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class EmploymentHistory
    {
        public int Id { get; set; }
        public string Uid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
    }
}