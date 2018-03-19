using System;
using System.ComponentModel.DataAnnotations;

namespace ProvalusApplicantTrackingHub.Models
{
    public class Employment
    {

        public Employment()
        {

            Address = new Address();
            EmployerPhone = "555-555-5555";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public bool Current { get; set; }

        [Required]
        public string Employer { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        public Address Address { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string EmployerPhone { get; set; }

        [Display(Name = "Starting Pay")]
        public decimal StartPay { get; set; }

        [Display(Name = "Ending Pay")]
        public decimal EndPay { get; set; }

        [Display(Name = "Pay Rate")]
        public PayRate PayRate { get; set; }

         [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

         public virtual JobApp JobApp { get; set; }



    }
}