using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class ApplicationSubPhase
    {
        public int Id { get; set; }

        //Foreign Key: AppPhase
        public int ApplicationPhaseId { get; set; }
        public ApplicationPhase ApplicationPhase { get; set; }

        public string Description {  get; set; }
    }
}
