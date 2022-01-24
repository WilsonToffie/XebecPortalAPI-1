using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class JobTypeHelper
    {
        public int Id { get; set; }

        //Foreign Key: Job
        public int JobId { get; set; }
        public Job Job { get; set; }

        //Foreign Key: JobType
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
    }
}
