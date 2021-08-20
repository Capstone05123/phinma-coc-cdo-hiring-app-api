using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Uid { get; set; }

        public string Date { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}