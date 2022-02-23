using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.DTOs
{
    public class RejectedCandidateDTO
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public ApplicationDTO Application { get; set; }

        public int UnsuccessfulReasonId { get; set; }

        public UnsuccessfulReasonDTO UnsuccessfulReason { get; set; }
    }
}
