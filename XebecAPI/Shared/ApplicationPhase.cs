using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class ApplicationPhase
    {
        public int Id { get; set; }
        public string Description {  get; set; }

        public List<ApplicationPhaseHelper> PhaseHelpers { get; set; }

        public List<JobApplicationPhase> JobPhases { get; set; }

        public List<ApplicationPhase> AppPhases { get; set; }
    }
}
