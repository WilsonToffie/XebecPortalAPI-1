using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using XebecAPI.Data;
using XebecAPI.IRepositories;
using XebecAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs.ViewModels;
using XebecAPI.Shared;
using XebecAPI.Shared.Security;

namespace XebecAPI.Repositories
{
    public class ApplicationPhaseHelperRepository : GenericRepository<ApplicationPhaseHelper>, IApplicationPhaseHelperRepository
    {
        public ApplicationPhaseHelperRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ApplicationPhaseHelper>> GetApplicationPhaseInfo(int AppUserId)
        {
            IQueryable<ApplicationPhaseHelper> queryFinal;
            //var job = new SqlParameter("jobId", JobId);
            //IQueryable<PersonalInformation> queryFinal = _context.PersonalInformations.
            //    FromSqlRaw("SELECT * from PersonalInformations Where UserId IN (SELECT UserId FROM Applications where JobId = @jobId)", job);
            queryFinal = from users in _context.ApplicationPhasesHelpers
                         join applications in _context.Applications.Where(a => a.AppUserId == AppUserId)
                             on users.ApplicationId equals applications.Id
                         select users;
            return await queryFinal.AsNoTracking().ToListAsync();
        }

        public async Task<List<ApplicationPhaseHelper>> GetApplicationPhaseInfoDetailed(int AppUserId, int jobId)
        {
            IQueryable<ApplicationPhaseHelper> queryFinal;
            //var job = new SqlParameter("jobId", JobId);
            //IQueryable<PersonalInformation> queryFinal = _context.PersonalInformations.
            //    FromSqlRaw("SELECT * from PersonalInformations Where UserId IN (SELECT UserId FROM Applications where JobId = @jobId)", job);
            queryFinal = from users in _context.ApplicationPhasesHelpers
                         join applications in _context.Applications.Where(a => a.AppUserId == AppUserId && a.JobId == jobId)
                             on users.ApplicationId equals applications.Id
                         select users;
            queryFinal = queryFinal.Include(a => a.Application).Include(s => s.Status).Include(p => p.ApplicationPhase);

            return await queryFinal.AsNoTracking().ToListAsync();
        }



        public async Task<List<myJobsViewModel>> GetApplicationPhaseInfoForUser(int AppUserId, int PhaseId)
        {
            IQueryable<ApplicationPhaseHelper> queryphase;
            IQueryable<myJobsViewModel> queryFinal = null;
            IQueryable<Job> queryJobs = null;
            if (PhaseId < 1 || PhaseId > 4)
            {
                queryphase = from users in _context.AppUser
                             join applications in _context.Applications.Where(a => a.AppUserId == AppUserId)
                                 on users.Id equals applications.AppUserId
                             join phases in _context.ApplicationPhasesHelpers
                                  on applications.Id equals phases.ApplicationId
                             select phases;
            }
            else
            {
                queryphase = from users in _context.AppUser
                             join applications in _context.Applications.Where(a => a.AppUserId == AppUserId)
                                 on users.Id equals applications.AppUserId
                             join phases in _context.ApplicationPhasesHelpers.Where(p => p.ApplicationPhaseId == PhaseId)
                                  on applications.Id equals phases.ApplicationId
                             select phases;
            }
            queryphase = queryphase.Include(s => s.Status).Include(p => p.ApplicationPhase);
            if (queryphase != null)
            {
                queryJobs = from phases in queryphase
                            join jobs in _context.Jobs
                            on phases.Application.JobId equals jobs.Id
                            select jobs;
            }
            if (queryJobs != null)
            {
                queryFinal = from phases in queryphase
                             join jobs in _context.Jobs
                             on phases.Application.JobId equals jobs.Id
                             select new myJobsViewModel() { Application = phases, Job = jobs };
            }


            return await queryFinal.AsNoTracking().ToListAsync();
        }

        public async Task<List<ApplicantViewModel>> GetApplicants(int jobId)
        {
            IQueryable<ApplicantViewModel> queryFinal;
            Random r = new Random();
            int i = 1;
            string[] Comments = new[]
            {
            "Awaiting resutls", "Good Choice", "Has Portential", "No Potential", "I like a lot", "Overqualified", "Balmy", "I don't know", "Maybe in the future?", "@Merril it's yours"
            };
            IQueryable<Application> queryapps = from applications in _context.Applications.Where(a => a.JobId == jobId)
                                                select applications;
            //IQueryable<PersonalInformation> queryFinal = _context.PersonalInformations.
            //    FromSqlRaw("SELECT * from PersonalInformations Where UserId IN (SELECT UserId FROM Applications where JobId = @jobId)", job);


            queryFinal = from apps in queryapps
                         join phase in _context.ApplicationPhasesHelpers.Include(a => a.ApplicationPhase)
                         on apps.Id equals phase.ApplicationId
                         join personal in _context.PersonalInformations
                         on apps.AppUserId equals personal.AppUserId
                         select new ApplicantViewModel()
                         {
                             Id = apps.AppUserId,
                             FirstName = personal.FirstName,
                             LastName = personal.LastName,
                             CstComment = Comments[r.Next(Comments.Length)],
                             CstMark = r.Next(1, 6),
                             InterviewComment = Comments[r.Next(Comments.Length)],
                             InterviewRating = r.Next(1, 6),
                             Phase = phase.ApplicationPhase.Description
                         };
            return await queryFinal.AsNoTracking().ToListAsync();
        }

    }
}
