using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.DTOs.ViewModels
{
    public class ProfileViewModel
    {
        public AdditionalInformation AdditionalInformation { get; set; }

        public List<Document> Document { get; set; }

        public List<Education> Educations { get; set; }

        public PersonalInformation PersonalInformation { get; set; }

        public ProfilePortfolioLink ProfilePortfolioLink { get; set; }

        public List<WorkHistory> WorkHistories { get; set; }

    }
}
