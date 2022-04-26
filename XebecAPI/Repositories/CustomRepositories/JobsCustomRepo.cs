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
              return await _context.Jobs.Include(t => t.JobTypes).ThenInclude(x => x.JobType).Include(p => p.JobPlatforms).Include(x => x.Department).AsNoTracking().ToListAsync();
        }

        public async Task<Job> GetJobTDetails(int JobId)
        {
            return await _context.Jobs.Where(j => j.Id == JobId).Include(t => t.JobTypes).ThenInclude(x => x.JobType).Include(p => p.JobPlatforms).Include(x => x.Department).AsNoTracking().FirstAsync();
        }
    }
}
