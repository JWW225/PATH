using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class EmploymentViewModel
    {
        public int JAID { get; set; }
        public Employment NewEmp { get; set; }
        public List<Employment> Employments { get; set; }
        public Address Address { get; set; }
    }
}