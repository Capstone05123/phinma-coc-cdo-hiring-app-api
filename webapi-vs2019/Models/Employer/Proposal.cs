using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_vs2019.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string DateSubmitted { get; set; }
        public string EmployeeUid { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeAddress { get; set; }
        public string CoverLetter { get; set; }
        public bool isApproved { get; set; }
    }
}