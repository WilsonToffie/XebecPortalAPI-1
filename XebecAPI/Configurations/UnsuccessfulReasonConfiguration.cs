using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XebecAPI.Shared;

namespace XebecAPI.Configurations
{
    public class UnsuccessfulReasonConfiguration : IEntityTypeConfiguration<UnsuccessfulReason>
    {
        public void Configure(EntityTypeBuilder<UnsuccessfulReason> builder)
        {
            builder.HasData(
                new UnsuccessfulReason
                {
                    Id = 1,
                    Reason = "Declined Offer"
                },
                new UnsuccessfulReason
                {
                    Id = 2,
                    Reason = "Hired Elsewhere"
                },
                new UnsuccessfulReason
                {
                    Id = 3,
                    Reason = "Does not fit ICP: Qualification Type",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 4,
                    Reason = "Does not fit ICP: University Type",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 5,
                    Reason = "Does not fit ICP: Salary Expectations Too High",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 6,
                    Reason = "Does not fit ICP: Age Category",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 7,
                    Reason = "Does not fit ICP: Too Junior",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 8,
                    Reason = "Does not fit ICP: Not in Desired Location",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 9,
                    Reason = "Does not fit ICP: Job Hopping",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 10,
                    Reason = "Does not fit ICP: References/MIE checks",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you for your interest in OneNebula!

                    We received an overwhelming response to the {{jobtitle}} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!

                    Best wishes,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 11,
                    Reason = "No Portfolio of Evidence"
                },
                new UnsuccessfulReason
                {
                    Id = 12,
                    Reason = "No Response from Candidate"
                },
                new UnsuccessfulReason
                {
                    Id = 13,
                    Reason = "Unsuccessful Assessment",
                    EmailTemplate = $@"Dear: {{firstname}},

                    Trust you are well.

                    We have completed the review of your coding assessment. Unfortunately upon reviewing, the team could not select you as the ideal candidate for this role as we are in need of someone a bit more senior for the current role we are recruiting for.

                    However, we do see the potential in you and would love to keep your application on file for other positions that may become available in our environment.

                    As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!

                    Regards,
                    {{sentname}}
                    {{senttitle}}
                    (www.1nebula.com)
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 14,
                    Reason = "Unsuccessful Screening: Not a culture fit"
                },
                new UnsuccessfulReason
                {
                    Id = 15,
                    Reason = "Unsuccessful First Round Interview",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.

                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!

                    Regards,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 16,
                    Reason = "Unsuccessful Technical Interview",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.

                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!

                    Regards,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 17,
                    Reason = "No relevant experience linked to the role"
                },
                new UnsuccessfulReason
                {
                    Id = 18,
                    Reason = "Unsuccessful CTO/MD interview",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.

                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!

                    Regards,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                },
                new UnsuccessfulReason
                {
                    Id = 19,
                    Reason = "Unsuccessful CEO Interview",
                    EmailTemplate = $@"Hi {{firstname}},

                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.

                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!

                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!

                    Regards,
                    {{sentname}} {{sentsurname}}
                    {{senttitle}}
 
                    OneNebula
                    "
                }
                );
        }
    }
}
