using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        /*Authentication*/
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<KeyAssigner> KeysAssigned { get; set; }
        /*Authentication*/

        public DbSet<AdditionalInformation> AdditionalInformations { get; set;}
        public DbSet<Application> Applications { get; set;}
        public DbSet<ApplicationPhase> ApplicationPhases { get; set; }
        public DbSet<ApplicationPhaseHelper> ApplicationPhasesHelpers { get; set;}
        public DbSet<Document> Documents { get; set;}
        public DbSet<Education> Educations { get; set;}
        public DbSet<Job> Jobs { get; set;}
        public DbSet<JobType> JobTypes { get; set;}
        public DbSet<JobTypeHelper> JobTypeHelpers { get; set;}
        public DbSet<LoginHelper> LoginHelpers { get; set;}
        public DbSet<PersonalInformation> PersonalInformations { get; set;}
        public DbSet<RegisterHelper> RegisterHelpers { get; set;}
        public DbSet<Status> Statuses { get; set;}
        public DbSet<WorkHistory> WorkHistories { get; set;}
        public DbSet<JobPlatform> JobPlatforms { get; set; }
        public DbSet<JobPlatformHelper> JobPlatformHelpers { get; set; }
        public DbSet<ProfilePortfolioLink> ProfilePortfolioLinks { get; set; }
        public DbSet<QuestionnaireHRForm> QuestionnaireHRForms { get; set; }
        public DbSet<QuestionnaireApplicantForm> QuestionnaireApplicantForms { get; set; }
        public DbSet<DeveloperAssigned> DevelopersAssigned { get; set; }
        public DbSet<ApplicationSubPhase> ApplicationSubPhases { get; set; }
        public DbSet<JobApplicationPhase> JobApplicationPhases { get; set; }
        public DbSet<Question> Questions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   
            modelBuilder.Entity<ApplicationPhaseHelper>().HasKey(ap => new { ap.ApplicationId, ap.ApplicationPhaseId, ap.StatusId });
            modelBuilder.Entity<JobApplicationPhase>().HasKey(ja => new { ja.ApplicationPhaseId, ja.JobId });
            modelBuilder.Entity<Application>().HasKey(a => new { a.AppUserId, a.JobId });
            modelBuilder.Entity<JobTypeHelper>().HasKey(jt => new { jt.JobTypeId, jt.JobId });
            modelBuilder.Entity<JobPlatformHelper>().HasKey(jp => new { jp.JobPlatformId, jp.JobId });
        }

    }
}