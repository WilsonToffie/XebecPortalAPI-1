using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.DTOs.ViewModels
{
    public class myJobsViewModel
    {
        public Job Job { get; set; }
        public ApplicationPhaseHelper Application { get; set; }
    }
}
