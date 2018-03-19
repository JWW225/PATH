using ProvalusApplicantTrackingHub.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public virtual JobApp JobApp { get; set; }
        public virtual Technology Technology { get; set; }
        public string Explanation { get; set; }
        public Proficiency Proficiency { get; set; }

       
    }
}