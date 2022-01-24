using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Data;
using XebecAPI.IRepositories;
using XebecAPI.Shared;

namespace XebecAPI.Repositories
{
    public class JobsCustomRepo : GenericRepository<Job>, IJobsCustomRepo
    {
        public JobsCustomRepo(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Job>> GetAllJobsFullDetails()
        {
            IQueryable<Job> queryUsers;

            queryUsers = from users in _context.Jobs
                         join info in _context.JobTypeHelpers
                          on users.Id equals info.JobId
                         select new Job()
                         {
                             Id = users.Id,
                             Company = users.Company,
                             Compensation = users.Compensation,
                             Description = users.Description,
                             Department = users.Department,
                             Title = users.Title,
                             MinimumExperience = users.MinimumExperience,
                             Location = users.Location,
                             JobTypes = _context.JobTypeHelpers.Where(b => b.JobId == users.Id).Include(p => p.JobType).ToList()
                         };

            return await queryUsers.AsNoTracking().ToListAsync();

        }

        public async Task<Job> GetJobTDetails(int JobId)
        {

            IQueryable<Job> queryUsers;
            queryUsers = from users in _context.Jobs.Where(a => a.Id == JobId)
                         join info in _context.JobTypeHelpers
                          on users.Id equals info.JobId
                         select new Job()
                         {
                             Id = users.Id,
                             Company = users.Company,
                             Compensation = users.Compensation,
                             Description = users.Description,
                             Department = users.Department,
                             Title = users.Title,
                             MinimumExperience = users.MinimumExperience,
                             Location = users.Location,
                             JobTypes = _context.JobTypeHelpers.Where(b => b.JobId == users.Id).Include(p => p.JobType).ToList()
                         };
            return await queryUsers.AsNoTracking().FirstAsync();
        }
    }
}
