using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using ProvalusApplicantTrackingHub.Controllers;
using ProvalusApplicantTrackingHub.Models;
using Microsoft.AspNet.Identity;

namespace ProvalusApplicantTrackingHub.Repository {
    public class PathRepository : IPathRepository {
        // static singleton instance
        private static PathRepository instance;
        //static property to access singleton
        public static PathRepository Repo {
            get {
                if (instance == null) {
                    instance = new PathRepository();
                }
                return instance;
            }
        }

        // Set instance of ApplicationDbContext
        private readonly ApplicationDbContext _context;

        public PathRepository() {

            _context = new ApplicationDbContext();
        }

        #region AppUser
        public ApplicationUser GetCurrentAppUser(string userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
        #endregion

        #region JobApp

        #region CreateJobApp()

        public void CreateJobApp(JobApp jobApp) {

            _context.JobApps.Add(jobApp);
            _context.SaveChanges();

        }

        #endregion

        #region DeleteJobApp()

        public void DeleteJobApp(int id) {

            JobApp jobApp = GetJobAppById(id);
            List<Comment> comments = GetCommentsByJobAppId(id);
            List<Education> educations = GetEducationsByJobAppId(id);
            List<Employment> employments = GetEmploymentsByJobAppId(id);
            List<Reference> references = GetReferencesByJobAppId(id);
            List<Skill> skills = GetSkillsByJobAppId(id);
            List<Address> addresses = GetAddressesByJobAppId(id);

            foreach (Comment comment in comments) {
                _context.Comments.Remove(comment);
            }

            foreach (Education education in educations) {
                _context.Educations.Remove(education);
            }

            foreach (Employment employment in employments) {
                _context.Employments.Remove(employment);
            }

            foreach (Reference reference in references) {
                _context.References.Remove(reference);
            }

            foreach (var skill in skills) {
                _context.Skills.Remove(skill);
            }

            foreach (Address address in addresses) {
                _context.Addresses.Remove(address);
            }

            _context.JobApps.Remove(jobApp);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateJobApp

        public void UpdateJobApp(JobApp jobApp) {

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region UpdateJobAppCpab()

        public void UpdateJobAppCpab(int jaid, int score) {

            JobApp jobApp = GetJobAppById(jaid);
            jobApp.CPABScore = score;

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region UpdateJobAppPt()

        public void UpdateJobAppPt(int jaid, int score) {

            JobApp jobApp = GetJobAppById(jaid);
            jobApp.PTScore = score;

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetJobAppById()

        public JobApp GetJobAppById(int id) {

            JobApp result = _context.JobApps.SingleOrDefault(j => j.Id == id);
            return result;

        }

        #endregion

        #region GetAllJobApps()

        public List<JobApp> GetAllJobApps() {

            List<JobApp> jobApps = _context.JobApps.ToList();
            return jobApps;
        }

        #endregion

        #region GetJobAppByApplicant()
        public JobApp GetJobAppByApplicant(string applicantId) {
            return _context.JobApps.SingleOrDefault(j => j.Applicant.Id == applicantId);
        }
        #endregion

        #region GetJobAppsByFirstName()

        public List<JobApp> GetJobAppsByFirstName(string fName) {

            List<JobApp> jobApps = _context.JobApps.Where(j => j.FName == fName).ToList();
            return jobApps;
        }

        #endregion

        #region GetJobAppsByLastName()

        public List<JobApp> GetJobAppsByLastName(string lName) {

            List<JobApp> jobApps = _context.JobApps.Where(j => j.LName == lName).ToList();
            return jobApps;

        }

        #endregion

        #region GetJobAppsByAvailableDate()

        public List<JobApp> GetJobAppsByAvailableDate(DateTime date) {

            List<JobApp> jobApps = _context.JobApps.Where(j => j.DateAvailable == date).ToList();
            return jobApps;

        }

        #endregion

        #region GetJobAppsByCpabScore()

        public List<JobApp> GetJobAppsByCpabScore(int score) {

            List<JobApp> jobApps = _context.JobApps.Where(j => j.CPABScore == score).ToList();
            return jobApps;

        }

        #endregion

        #region GetJobAppsBtPtScore()

        public List<JobApp> GetJobAppsByPtScore(int score) {

            List<JobApp> jobApps = _context.JobApps.Where(j => j.PTScore == score).ToList();
            return jobApps;

        }

        #endregion

        #region GetJobAppsByPosition()

        public List<JobApp> GetJobAppsByPosition(Position position) {
            List<JobApp> jobApps = _context.JobApps.Where(j => j.Position == position).ToList();
            return jobApps;
        }

        #endregion

        #region UpdateCpabScore()

        public void UpdateCpabScore(int score, int jaid) {
            JobApp jobApp = GetJobAppById(jaid);
            jobApp.CPABScore = score;

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region UpdatePtScore()

        public void UpdatePtScore(int score, int jaid) {
            JobApp jobApp = GetJobAppById(jaid);
            jobApp.PTScore = score;

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion

        #region UpdateResume()

        public void UpdateResume(string location, int jaid) {
            JobApp jobApp = GetJobAppById(jaid);
            jobApp.Resume = location;

            _context.Entry(jobApp).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #endregion

        #region Employment

        #region GetEmploymentsByJobAppId()

        public List<Employment> GetEmploymentsByJobAppId(int id) {

            List<Employment> result = _context.Employments.Where(e => e.JobApp.Id == id).ToList();
            return result;
        }

        #endregion

        #region CreateEmployment()

        public void CreateEmployment(Employment employment) {
            try
            {
                CreateAddress(employment.Address);
                _context.Employments.Add(employment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        #endregion

        #region DeleteEmployment()

        public void DeleteEmployment(int id) {

            Employment employment = GetEmploymentById(id);

            _context.Employments.Remove(employment);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateEmployment()

        public void UpdateEmployment(Employment employment) {

            _context.Entry(employment).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetEmploymentById()

        public Employment GetEmploymentById(int id) {
            Employment employment = _context.Employments.SingleOrDefault(e => e.Id == id);
            return employment;
        }

        #endregion

        #region GetAllEmployments();

        public List<Employment> GetAllEmployments() {

            List<Employment> result = _context.Employments.ToList();
            return result;
        }

        #endregion


        #endregion

        #region References

        #region GetReferencesByJobAppId()

        public List<Reference> GetReferencesByJobAppId(int id) {
            List<Reference> result = _context.References.Where(r => r.JobApp.Id == id).ToList();
            return result;
        }


        #endregion

        #region CreateReference()

        public void CreateReference(Reference reference) {

            _context.References.Add(reference);
            _context.SaveChanges();
        }

        #endregion

        #region DeleteReference()

        public void DeleteReference(int id) {
            Reference reference = GetReferenceById(id);
            _context.References.Remove(reference);
            _context.SaveChanges();
        }

        #endregion

        #region UpdateReference()

        public void UpdateReference(Reference reference) {

            _context.Entry(reference).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetReferenceById()

        public Reference GetReferenceById(int id) {
            Reference reference = _context.References.SingleOrDefault(r => r.Id == id);
            return reference;
        }

        #endregion

        #region GetAllReferences()

        public List<Reference> GetAllReferences() {

            List<Reference> references = _context.References.ToList();
            return references;

        }

        #endregion

        #endregion

        #region Education

        #region CreateEducation()

        public void CreateEducation(Education education) {

            _context.Educations.Add(education);
            _context.SaveChanges();

        }

        #endregion

        #region DeleteEducation()

        public void DeleteEducation(int id) {

            Education education = GetEducationById(id);
            _context.Educations.Remove(education);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateEducation()

        public void UpdateEducation(Education education) {

            _context.Entry(education).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetEducationById()

        public Education GetEducationById(int id) {

            Education education = _context.Educations.SingleOrDefault(e => e.Id == id);
            return education;

        }

        #endregion

        #region GetEducationsByJobAppId()

        public List<Education> GetEducationsByJobAppId(int id) {
            List<Education> result = _context.Educations.Where(e => e.JobApp.Id == id).ToList();
            return result;
        }

        #endregion

        #region GetAllEducations()

        public List<Education> GetAllEducations() {

            List<Education> educations = _context.Educations.ToList();
            return educations;

        }

        #endregion

        #endregion

        #region Skills

        #region CreateSkill()

        public void CreateSkill(Skill skill) {

            _context.Skills.Add(skill);
            _context.SaveChanges();

        }

        #endregion

        #region DeleteSkill()

        public void DeleteSkill(int id) {

            Skill skill = GetSkillById(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateSkill

        public void UpdateSkill(Skill skill) {

            _context.Entry(skill).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetSkillsByJobId()

        public List<Skill> GetSkillsByJobAppId(int id) {

            List<Skill> result = _context.Skills.Where(s => s.JobApp.Id == id).ToList();
            return result;
        }

        #endregion

        #region GetSkillById()

        public Skill GetSkillById(int id) {

            Skill skill = _context.Skills.SingleOrDefault(s => s.Id == id);
            return skill;

        }

        #endregion

        #region GetSkillsByTechnology()

        public List<Skill> GetSkillsByTechnology(Technology technology) {

            List<Skill> skills = _context.Skills.Where(s => s.Technology == technology).ToList();
            return skills;

        }

        #endregion

        #region GetAllSkills()

        public List<Skill> GetAllSkills() {

            List<Skill> skills = _context.Skills.ToList();
            return skills;

        }

        #endregion


        #endregion

        #region Comments

        #region CreateComment()

        public void CreateComment(Comment comment) {

            _context.Comments.Add(comment);
            _context.SaveChanges();

        }

        #endregion

        #region DeleteComment()

        public void DeleteComment(int id) {

            Comment comment = GetCommentById(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateComment

        public void UpdateComment(Comment comment) {

            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetCommentById()

        public Comment GetCommentById(int id) {

            Comment comment = _context.Comments.SingleOrDefault(c => c.Id == id);
            return comment;

        }

        #endregion

        #region GetCommentsByJobAppId()

        public List<Comment> GetCommentsByJobAppId(int jaid) {

            List<Comment> comments = _context.Comments.Where(c => c.JobApp.Id == jaid).ToList();
            return comments;

        }

        #endregion

        #region GetCommentsByAuthor()

        public List<Comment> GetCommentsByAuthor(string userId) {

            List<Comment> comments = _context.Comments.Where(c => c.Author.Id == userId).ToList();
            return comments;

        }

        #endregion

        #region GetAllComments()

        public List<Comment> GetAllComments() {

            List<Comment> comments = _context.Comments.ToList();
            return comments;

        }

        #endregion

        #endregion

        #region Addresses

        #region CreateAddress()

        public void CreateAddress(Address address) {
            try
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        #endregion

        #region DeleteAddress()

        public void DeleteAddress(int id) {

            Address address = GetAddressById(id);
            _context.Addresses.Remove(address);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateAddress()

        public void UpdateAddress(Address address) {

            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetAddressById()

        public Address GetAddressById(int id) {

            Address address = _context.Addresses.SingleOrDefault(a => a.Id == id);
            return address;

        }

        #endregion

        #region GetAddressesByType()

        public List<Address> GetAddressesByType(AddressType type, int jaid) {

            List<Address> addresses = _context.Addresses.Where(a => a.Type == type && a.JobApp.Id == jaid).ToList();
            return addresses;

        }

        #endregion

        #region GetAddressesByJobAppId()

        public List<Address> GetAddressesByJobAppId(int jaid) {

            List<Address> addresses = _context.Addresses.Where(a => a.JobApp.Id == jaid).ToList();
            return addresses;

        }
        #endregion

        #endregion

        #region Technologies

        #region CreateTechnology()

        public void CreateTechnology(Technology technology) {

            _context.Technologies.Add(technology);
            _context.SaveChanges();

        }

        #endregion

        #region DeleteTechnology()

        public void DeleteTechnology(int id) {

            Technology technology = GetTechnologyById(id);
            List<Skill> skills = GetSkillsByTechnology(technology);

            foreach (Skill skill in skills) {
                _context.Skills.Remove(skill);
            }
            _context.Technologies.Remove(technology);
            _context.SaveChanges();

        }

        #endregion

        #region UpdateTechnology()

        public void UpdateTechnology(Technology technology) {

            _context.Entry(technology).State = EntityState.Modified;
            _context.SaveChanges();

        }

        #endregion

        #region GetTechnologyById()

        public Technology GetTechnologyById(int id) {

            Technology technology = _context.Technologies.SingleOrDefault(t => t.Id == id);
            return technology;

        }

        #endregion

        #region GetTechnologiesByPosition()

        public List<Technology> GetTechnologiesByPosition(Position position) {

            List<Technology> technologies = _context.Technologies.Where(t => t.Position == position).ToList();
            return technologies;

        }

        #endregion

        #region GetAllTechnologies()

        public List<Technology> GetAllTechnologies() {

            List<Technology> technologies = _context.Technologies.ToList();
            return technologies;
        }

        #endregion

        #endregion

    }
}