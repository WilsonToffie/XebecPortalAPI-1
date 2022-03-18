using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.IRepositories;
using XebecAPI.Shared.Security;

namespace XebecAPI.Repositories
{
    public class EmailRepo : IEmailRepo
    {
        public Task<bool> ConfrimRegisterKey(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
