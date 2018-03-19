using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models {
    public class Education {
        [Key]
        public int Id { get; set; }

        public string School { get; set; }

        public virtual Address Location { get; set; }

        [Display (Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string Major { get; set; }

        public string Degree { get; set; }

        public virtual JobApp JobApp { get; set; }

        public Education()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }
}