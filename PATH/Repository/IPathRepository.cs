using ProvalusApplicantTrackingHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProvalusApplicantTrackingHub.Repository {
    public interface IPathRepository {

        #region AppUser
        ApplicationUser GetCurrentAppUser(string userId);
        #endregion

        #region JobApp

        void CreateJobApp(JobApp jobApp);
        void DeleteJobApp(int id);
        void UpdateJobApp(JobApp jobApp);
        void UpdateJobAppCpab(int id, int score);
        void UpdateJobAppPt(int id, int score);
        JobApp GetJobAppById(int id);
        List<JobApp> GetAllJobApps();
        List<JobApp> GetJobAppsByFirstName(string fName);
        List<JobApp> GetJobAppsByLastName(string lName);
        List<JobApp> GetJobAppsByAvailableDate(DateTime date);
        List<JobApp> GetJobAppsByCpabScore(int score);
        List<JobApp> GetJobAppsByPtScore(int score);
        List<JobApp> GetJobAppsByPosition(Position position);
        void UpdateCpabScore(int score, int id);
        void UpdatePtScore(int score, int id);
        void UpdateResume(string location, int jaid);
        JobApp GetJobAppByApplicant(string applicantId);

        #endregion

        #region Employment

        void CreateEmployment(Employment employment);
        void DeleteEmployment(int id);
        void UpdateEmployment(Employment employment);
        Employment GetEmploymentById(int id);
        List<Employment> GetEmploymentsByJobAppId(int id);
        List<Employment> GetAllEmployments();

        #endregion

        #region References

        void CreateReference(Reference reference);
        void DeleteReference(int id);
        void UpdateReference(Reference reference);
        Reference GetReferenceById(int id);
        List<Reference> GetReferencesByJobAppId(int id);

        #endregion

        #region Education

        void CreateEducation(Education education);
        void DeleteEducation(int id);
        void UpdateEducation(Education education);
        Education GetEducationById(int id);
        List<Education> GetEducationsByJobAppId(int id);
        List<Education> GetAllEducations();

        #endregion

        #region Skills

        void CreateSkill(Skill skill);
        void DeleteSkill(int id);
        void UpdateSkill(Skill skill);
        List<Skill> GetSkillsByJobAppId(int id);
        Skill GetSkillById(int id);
        List<Skill> GetSkillsByTechnology(Technology technology);
        List<Skill> GetAllSkills();

        #endregion

        #region Comments

        void CreateComment(Comment comment);
        void DeleteComment(int id);
        void UpdateComment(Comment comment);
        Comment GetCommentById(int id);
        List<Comment> GetCommentsByJobAppId(int jaid);
        List<Comment> GetCommentsByAuthor(string userId);
        List<Comment> GetAllComments();

        #endregion

        #region Address

        void CreateAddress(Address address);
        void DeleteAddress(int id);
        void UpdateAddress(Address address);
        Address GetAddressById(int id);
        List<Address> GetAddressesByType(AddressType type, int jaid);
        List<Address> GetAddressesByJobAppId(int jaid);

        #endregion

        #region Technologies

        void CreateTechnology(Technology technology);
        void DeleteTechnology(int id);
        void UpdateTechnology(Technology technology);
        Technology GetTechnologyById(int id);
        List<Technology> GetTechnologiesByPosition(Position position);
        List<Technology> GetAllTechnologies();

        #endregion

        #region Client

        

        #endregion


    }
}
