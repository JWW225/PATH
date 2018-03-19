using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        public virtual JobApp JobApp { get; set; }
    }
}