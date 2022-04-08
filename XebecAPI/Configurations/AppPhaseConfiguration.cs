using XebecAPI.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Configurations
{
    public class AppPhaseConfiguration : IEntityTypeConfiguration<ApplicationPhase>
    {
        public void Configure(EntityTypeBuilder<ApplicationPhase> builder)
        {
            builder.HasData(
                new ApplicationPhase
                {
                    Id = 1,
                    Description = "Applied"
                },
                new ApplicationPhase
                {
                    Id = 3,
                    Description = "Schedule Phone Screen"
                },
                new ApplicationPhase
                {
                    Id = 5,
                    Description = "Phone Screened"
                },
                new ApplicationPhase
                {
                    Id = 25,
                    Description = "MS Teams Screened",
                    EmailTemplate = $@"Hi , {{firstname}}

I received your application and would love to learn more about you and answer any questions you may have about 1Nebula or the {{ jobtitle }} position.

Could you send me a few times when you’d be available for a 30 minute Microsoft Teams call in the next few days ? I will be sending you a link to the meeting based on your availability.

I look forward to our conversation,

{{ sentname}}
            {{ sentsurname}}
            {{ senttitle}}

            1Nebula"
                },
                new ApplicationPhase
                {
                    Id = 26,
                    Description = "First Round Interview",
                    EmailTemplate = $@"Dear: {{firstname}} {{surname}},

It was so lovely chatting with you and getting to know you a bit more. 

I was overall impressed with your background and experience and have consulted with the team on your application for the {{jobtitle}} position.

The team has decided to progress you to the first stage which is the first round interview. Details of the interview are listed below. Should you be available, a Microsoft teams meeting link will be sent to your email address linked to this application.

Date: {{date}}
Time: {{time}}
Medium: MS Teams
Interview Panel: {{panel}}

No need to prepare anything as this will be a culture interview as the team would like to get to know you and understand your skill set in relation to your career goals.

I look forward to your response.
Kind regards,
{{sentname}} {{sentsurname}}
{{senttitle}}
1Nebula
www.1nebula.com"
                },
                new ApplicationPhase
                {
                    Id = 27,
                    Description = "Assessment Phase",
                    EmailTemplate = $@"Dear: {{firstname}} {{surname}},

Trust you are well.

It is with great excitement we now invite you to move forward in the recruitment process with 1Nebula. The next phase will be the completion of an assessment. 

Attached you will find our {{jobtitle}}. We would like for you to present this to us via MS teams on:

Date: {{date}}
Time: {{time}}
Presentation Panel: {{panel}}

Kindly have a look and let me know if you would like to proceed as well as confirm your availability.

Kind regards,
{{sentname}} {{sentsurname}}
{{senttitle}}
1Nebula
www.1nebula.com"
                },

                 new ApplicationPhase
                 {
                     Id = 28,
                     Description = "Second Round Interview",
                     EmailTemplate = $@"Dear: {{firstname}} {{surname}},

Trust you are well.

Hi {{firstname}},

Trust you are well.

We were extremely impressed with your coding assessment and we would like for you to move forward to the next step of the Recruitment process, which is the Technical interview. It will entail getting to know you and assessing your capabilities. Details of the interview are listed below. Should you be available, a Microsoft teams meeting link will be sent to your email address linked to this application.

Date: {{date}}
Time: {{time}}
Medium: MS Teams
Interview Panel: {{panel}}

Video will be needed for this session so please ensure you are in a well-lit room with a strong connection and no distractions.

Looking forward to your response.


Kind Regards,
{{sentname}} {{sentsurname}}
{{senttitle}}
1Nebula
www.1nebula.com"
                 },
                new ApplicationPhase
                {
                    Id = 29,
                    Description = "Waiting on Manager feedback"
                },
               new ApplicationPhase
               {
                   Id = 30,
                   Description = "CTO/MD Interview"
               },
               new ApplicationPhase
               {
                   Id = 31,
                   Description = "CEO Interview",
                   EmailTemplate = $@"Dear {{firstname}},

We are delighted to have you move forward to the final stage of the recruitment process. This will be your final interview with the CEO, Mr Daniel Nel.


Date: {{date}}
Time: {{time}}
Medium: MS Teams

Wishing you the best of luck!

Regards,
{{sentname}} {{sentsurname}}
(www.1nebula.com)"
               },
               new ApplicationPhase
               {
                   Id = 32,
                   Description = "Checking References",
                   EmailTemplate = $@"Hi {{firstname}},

Could you please send me 3 professional references for us to contact? Be sure to include their names, titles, companies, phone numbers, and email addresses.

Thank you!

{{sentname}}{{sentsurname}}
{{senttitle}}
OneNebula"
               },
        new ApplicationPhase
        {
            Id = 33,
            Description = "Offer Sent"
        },
        new ApplicationPhase
        {
            Id = 34,
            Description = "Offer Pending – Candidate"
        },
        new ApplicationPhase
        {
            Id = 35,
            Description = "Offer Pending - Second Opinion"
        },
        new ApplicationPhase
        {
            Id = 36,
            Description = "Final Phase"
        }

        );
        }
    }
}
