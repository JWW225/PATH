using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
    }
}