using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models {
    public class Address {

        public Address()
        {
            Line1 = "Address Line 1";
            Line2 = "";
            City = "City";
            State = State.AK;
            ZIP = "00000";

        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display (Name = "Address Line 1 (street address)")]
        public string Line1 { get; set; }

        [Display (Name = "Address Line 2 (apartment number, etc.)")]
        public string Line2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        [Display(Name = "ZIP Code")]
        public string ZIP { get; set; }

        public virtual JobApp JobApp { get; set; }
        
        public AddressType Type { get; set; }
    }
}