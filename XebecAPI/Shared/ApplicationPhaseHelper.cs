using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class ApplicationPhaseHelper
    {
        public int Id { get; set; }
        public DateTime TimeMoved { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }

        //foreign key: Application
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        //foreign key: ApplicationPhase
        public int ApplicationPhaseId { get; set; }
        public ApplicationPhase ApplicationPhase { get; set; }

    }

}
