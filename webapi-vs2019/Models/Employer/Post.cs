using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string DatePosted { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public double Salary { get; set; }
        public string ProjectLength { get; set; }
        public string ExperienceLevel { get; set; }
        public bool IsVisible { get; set; }
    }
}