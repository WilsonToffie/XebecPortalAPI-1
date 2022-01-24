using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.DTOs;

namespace XebecAPI.DTOs
{
    public class ApplicationSubPhaseDTO
    {
        public int Id { get; set; }

        //FK
        public int ApplicationPhaseId { get; set; }
        public ApplicationPhaseDTO ApplicationPhase { get; set; }

        public string Description { get; set; }
    }
}
