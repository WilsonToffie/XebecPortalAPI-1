using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs.ViewModels;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.IRepositories
{
    public interface IUsersCustomRepo
    {
        Task<List<PersonalInformation>> SearchApplicants(int JobId, string SearchQuery, string ethnicityFiler, string GenderFilter, string disabilityFilter);
        Task<List<PersonalInformation>> GetApplicantsDetailsByJobId(int JobId);
        Task<List<AppUser>> GetApplicantIds(int JobId);
        Task<List<PersonalInformation>> GetPersonalByAdditional(string disability, string gender, string ehtnicity);
        Task<List<CandidateViewModel>> GetCandidateDetails(int JobId);

        Task<List<ProfileViewModel>> GetProfile(int AppUserId);

        Task<List<QuestionnaireHRForm>> GetQuestions(int AppUserId);

        Task<List<JobApplicationPhase>> SearchPhasebyJob(int job);

        Task<List<PersonalInformation>> SearchCandidate(string role, string name);
    }
}
