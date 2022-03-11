using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Shared
{
    public class UnsuccessfulReason
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public string? EmailTemplate { get; set; }

        public List<RejectedCandidate> _RejectedCandidates { get; set; }
    }
}
