using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class JobPlatformHelper
    {
        public int Id { get; set; } 
        
        //Foreign Key: Job
        public int JobId { get; set; }
        public Job Job { get; set; }

        //ForeignKey: JobPlatform
        public int JobPlatformId { get; set; }
        public JobPlatform JobPlatform { get; set; }
        
    }
}