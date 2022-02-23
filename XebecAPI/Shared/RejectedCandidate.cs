using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class RejectedCandidate
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public Application Application { get; set; }

        public int UnsuccessfulReasonId { get; set; }

        public UnsuccessfulReason UnsuccessfulReason { get; set; }
    }
}
