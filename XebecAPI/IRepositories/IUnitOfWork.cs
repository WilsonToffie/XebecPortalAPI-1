using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        /*Authentication*/
        IGenericRepository<AppUser> AppUsers { get; }
        IGenericRepository<KeyAssigner> KeysAssigned { get; }
        /*Authentication*/

        //Model Repositories
        IGenericRepository<AdditionalInformation> AdditionalInformation { get; }
        IGenericRepository<Application> Applications { get; }
        IGenericRepository<ApplicationPhase> Phases { get; }
        IGenericRepository<ApplicationPhaseHelper> ApplicationPhaseHelpers { get; }
        IGenericRepository<Document> Documents { get; }
        IGenericRepository<Education> Education { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<JobType> JobTypes { get; }
        IGenericRepository<JobTypeHelper> JobTypeHelpers { get; }
        IGenericRepository<LoginHelper> LoginHelpers { get; }
        IGenericRepository<PersonalInformation> PersonalInformation { get; }
        IGenericRepository<RegisterHelper> RegisterHelpers { get; }
        IGenericRepository<Status> Statuses { get; }
        IGenericRepository<WorkHistory> WorkHistory { get; }
        
        IGenericRepository<JobPlatform> JobPlatforms { get; }
        IGenericRepository<JobPlatformHelper> JobPlatformHelpers { get; }

        IGenericRepository<ProfilePortfolioLink> ProfilePortfolioLinks { get; }

        IGenericRepository<QuestionnaireApplicantForm> QuestionnaireApplicantForms { get; }

        IGenericRepository<QuestionnaireHRForm> QuestionnaireHRForms{ get; }

        IGenericRepository<ApplicationSubPhase> ApplicationSubPhases { get; }

        IGenericRepository<JobApplicationPhase> JobApplicationPhases { get; }

        IGenericRepository<Question> Questions { get; }


        //Saving to the DB
        Task Save();

    }
}
