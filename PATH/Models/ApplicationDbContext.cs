using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProvalusApplicantTrackingHub.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region DbSets
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<JobApp> JobApps { get; set; }
        public DbSet<Education> Educations { get; set; }
        #endregion


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}