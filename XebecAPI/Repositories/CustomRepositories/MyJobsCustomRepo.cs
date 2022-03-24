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
    public class MyJobsCustomRepo : GenericRepository<Application>, IMyJobsCustomRepo
    {
        public MyJobsCustomRepo(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Application>> GetAllApplicationDetails(int AppUserId)
        {
            return await _context.Applications.Where(x => x.AppUserId == AppUserId).Include(t => t.Job).Include(p => p.ApplicationPhase).AsNoTracking().ToListAsync();
        }
    }
}
