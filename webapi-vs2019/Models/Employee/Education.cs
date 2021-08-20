using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Degree { get; set; }
        public string AreaOfStudy { get; set; }
        public string SchoolName { get; set; }
        public string SchoolYear { get; set; }
    }
}