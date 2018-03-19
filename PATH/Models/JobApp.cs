using System.Web.Compilation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProvalusApplicantTrackingHub.Repository;

namespace ProvalusApplicantTrackingHub.Models
{
    public class JobApp {

        #region properties
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser Applicant { get; set; }

        [Display(Name = "Position")]
        public Position Position { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        //[Display(Name = "Social Security Number")]
        //public string SSN { get; set; }

        //[Display(Name = "Date of Birth")]
        //[Required]
        //public DateTime DOB { get; set; }


        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Primary Phone")]
        public string PrimaryPhone { get; set; }

        [Display(Name = "Is Mobile")]
        public bool PPhoneIsMobile { get; set; }

        [Phone]
        [Display(Name = "Secondary Phone")]
        public string SecondaryPhone { get; set; }

        [Display(Name = "Is Mobile")]
        public bool SPhoneIsMobile { get; set; }

        [Display(Name = "Are you willing to relocate?")]
        public bool CanRelocate { get; set; }

        [Required]
        [Display(Name = "Date Available to Start")]
        public DateTime DateAvailable { get; set; }


        public DateTime DateEntered { get; set; }

        [Display(Name = "Are you authorized to work in The United States?")]
        public bool AuthorizedToWork { get; set; }

        [Display(Name = "If hired, are you willing to take a drug screening?")]
        public bool DrugScreen { get; set; }

        [Display(Name = "Have you served or are you currently serving in the US Military")]
        public bool Military { get; set; }

        [Display(Name = "What Branch?")]
        public MilBranch MilBranch { get; set; }

        [Display(Name = "Have you ever been convicted of a felony")]
        public bool Conviction { get; set; }

        [Display(Name = "Please Explain:")]
        public string Explanation { get; set; }

        // Will store the signature as an array of bytes
        [UIHint("SignaturePad")]
        public byte[] Signature { get; set; }

        [Display(Name = "Why is this company right for you")]
        public string About { get; set; }

        public string Resume { get; set; }

        [Display(Name = "CPAB Test Score")]
        public int CPABScore { get; set; }

        [Display(Name = "Personality Test Score")]
        public int PTScore { get; set; }

        [Display(Name = "Client Assignment")]
        public string Assignment { get; set; }

        [Display(Name = "Active Status")]
        public Status Status { get; set; }

        [Display(Name = "Where did you hear about us?")]
        public Source Source { get; set; }

        [Display(Name = "Employment Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Date Last Edited")]
        public DateTime LastEdit { get; set; }

        public Branch Branch { get; set; }
        #endregion

        #region Methods
        private IPathRepository repo = new PathRepository();

        public List<Education> EducationList(int id) {
            List<Education> result = repo.GetEducationsByJobAppId(id);
            return result;
        }

        public List<Reference> ReferenceList(int id) {
            List<Reference> result = repo.GetReferencesByJobAppId(id);
            return result;
        }

        public List<Employment> EmploymentList(int id) {
            List<Employment> result = repo.GetEmploymentsByJobAppId(id);
            return result;
        }

        public List<Skill> SkillList(int id) {
            List<Skill> result = repo.GetSkillsByJobAppId(id);
            return result;
        }

        #endregion

        #region Constructor

        public JobApp() {
            DateAvailable = DateTime.Now;
            DateEntered = DateTime.Now;
            LastEdit = DateTime.Now;
        }
        #endregion
    }
}