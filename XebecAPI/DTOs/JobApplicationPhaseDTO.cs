using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs;

namespace XebecAPI.DTOs
{
    public class JobApplicationPhaseDTO
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public JobDTO Job { get; set; }
        public int ApplicationPhaseId { get; set; }
        public ApplicationPhaseDTO ApplicationPhase { get; set; }
    }
}
