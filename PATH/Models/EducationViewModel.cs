using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class EducationViewModel
    {
        public int JAID { get; set; }

        public Education NewEducation { get; set; }

        public List<Education> Educations { get; set; }
    }
}