using Microsoft.EntityFrameworkCore.Migrations;

namespace XebecAPI.Migrations
{
    public partial class prepoulated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnswerTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Number" },
                    { 2, "Long Text" },
                    { 3, "Short Text" },
                    { 4, "Date/Time" },
                    { 5, "Boolean" },
                    { 6, "File Upload" },
                    { 7, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationPhases",
                columns: new[] { "Id", "Description", "EmailTemplate" },
                values: new object[,]
                {
                    { 36, "Final Phase", null },
                    { 35, "Offer Pending - Second Opinion", null },
                    { 34, "Offer Pending – Candidate", null },
                    { 33, "Offer Sent", null },
                    { 32, "Checking References", "Hi {firstname},\r\n\r\nCould you please send me 3 professional references for us to contact? Be sure to include their names, titles, companies, phone numbers, and email addresses.\r\n\r\nThank you!\r\n\r\n{sentname}{sentsurname}\r\n{senttitle}\r\nOneNebula" },
                    { 31, "CEO Interview", "Dear {firstname},\r\n\r\nWe are delighted to have you move forward to the final stage of the recruitment process. This will be your final interview with the CEO, Mr Daniel Nel.\r\n\r\n\r\nDate: {date}\r\nTime: {time}\r\nMedium: MS Teams\r\n\r\nWishing you the best of luck!\r\n\r\nRegards,\r\n{sentname} {sentsurname}\r\n(www.1nebula.com)" },
                    { 30, "CTO/MD Interview", null },
                    { 26, "First Round Interview", "Dear: {firstname} {surname},\r\n\r\nIt was so lovely chatting with you and getting to know you a bit more. \r\n\r\nI was overall impressed with your background and experience and have consulted with the team on your application for the {jobtitle} position.\r\n\r\nThe team has decided to progress you to the first stage which is the first round interview. Details of the interview are listed below. Should you be available, a Microsoft teams meeting link will be sent to your email address linked to this application.\r\n\r\nDate: {date}\r\nTime: {time}\r\nMedium: MS Teams\r\nInterview Panel: {panel}\r\n\r\nNo need to prepare anything as this will be a culture interview as the team would like to get to know you and understand your skill set in relation to your career goals.\r\n\r\nI look forward to your response.\r\nKind regards,\r\n{sentname} {sentsurname}\r\n{senttitle}\r\n1Nebula\r\nwww.1nebula.com" },
                    { 28, "Second Round Interview", "Dear: {firstname} {surname},\r\n\r\nTrust you are well.\r\n\r\nHi {firstname},\r\n\r\nTrust you are well.\r\n\r\nWe were extremely impressed with your coding assessment and we would like for you to move forward to the next step of the Recruitment process, which is the Technical interview. It will entail getting to know you and assessing your capabilities. Details of the interview are listed below. Should you be available, a Microsoft teams meeting link will be sent to your email address linked to this application.\r\n\r\nDate: {date}\r\nTime: {time}\r\nMedium: MS Teams\r\nInterview Panel: {panel}\r\n\r\nVideo will be needed for this session so please ensure you are in a well-lit room with a strong connection and no distractions.\r\n\r\nLooking forward to your response.\r\n\r\n\r\nKind Regards,\r\n{sentname} {sentsurname}\r\n{senttitle}\r\n1Nebula\r\nwww.1nebula.com" },
                    { 27, "Assessment Phase", "Dear: {firstname} {surname},\r\n\r\nTrust you are well.\r\n\r\nIt is with great excitement we now invite you to move forward in the recruitment process with 1Nebula. The next phase will be the completion of an assessment. \r\n\r\nAttached you will find our {jobtitle}. We would like for you to present this to us via MS teams on:\r\n\r\nDate: {date}\r\nTime: {time}\r\nPresentation Panel: {panel}\r\n\r\nKindly have a look and let me know if you would like to proceed as well as confirm your availability.\r\n\r\nKind regards,\r\n{sentname} {sentsurname}\r\n{senttitle}\r\n1Nebula\r\nwww.1nebula.com" },
                    { 25, "MS Teams Screened", "Hi , {firstname}\r\n\r\nI received your application and would love to learn more about you and answer any questions you may have about 1Nebula or the { jobtitle } position.\r\n\r\nCould you send me a few times when you’d be available for a 30 minute Microsoft Teams call in the next few days ? I will be sending you a link to the meeting based on your availability.\r\n\r\nI look forward to our conversation,\r\n\r\n{ sentname}\r\n            { sentsurname}\r\n            { senttitle}\r\n\r\n            1Nebula" },
                    { 5, "Phone Screened", null },
                    { 3, "Schedule Phone Screen", null },
                    { 1, "Applied", null },
                    { 29, "Waiting on Manager feedback", null }
                });

            migrationBuilder.InsertData(
                table: "JobPlatforms",
                columns: new[] { "Id", "PlatformName" },
                values: new object[,]
                {
                    { 5, "Stactize" },
                    { 3, "48Software" },
                    { 4, "Oneview" },
                    { 1, "Main 1Nebula Platform" },
                    { 2, "Xebec Platform" }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Freelance" },
                    { 2, "Full Time" },
                    { 3, "Part Time" },
                    { 4, "Contract" },
                    { 5, "Temporary" },
                    { 6, "Internship" }
                });

            migrationBuilder.InsertData(
                table: "UnsuccessfulReasons",
                columns: new[] { "Id", "EmailTemplate", "Reason" },
                values: new object[,]
                {
                    { 18, "Hi {firstname},\r\n\r\n                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.\r\n\r\n                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!\r\n\r\n                    Regards,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Unsuccessful CTO/MD interview" },
                    { 12, null, "No Response from Candidate" },
                    { 13, "Dear: {firstname},\r\n\r\n                    Trust you are well.\r\n\r\n                    We have completed the review of your coding assessment. Unfortunately upon reviewing, the team could not select you as the ideal candidate for this role as we are in need of someone a bit more senior for the current role we are recruiting for.\r\n\r\n                    However, we do see the potential in you and would love to keep your application on file for other positions that may become available in our environment.\r\n\r\n                    As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!\r\n\r\n                    Regards,\r\n                    {sentname}\r\n                    {senttitle}\r\n                    (www.1nebula.com)\r\n                    ", "Unsuccessful Assessment" },
                    { 17, null, "No relevant experience linked to the role" },
                    { 15, "Hi {firstname},\r\n\r\n                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.\r\n\r\n                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!\r\n\r\n                    Regards,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Unsuccessful First Round Interview" },
                    { 16, "Hi {firstname},\r\n\r\n                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.\r\n\r\n                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!\r\n\r\n                    Regards,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Unsuccessful Technical Interview" },
                    { 11, null, "No Portfolio of Evidence" },
                    { 14, null, "Unsuccessful Screening: Not a culture fit" },
                    { 10, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: References/MIE checks" }
                });

            migrationBuilder.InsertData(
                table: "UnsuccessfulReasons",
                columns: new[] { "Id", "EmailTemplate", "Reason" },
                values: new object[,]
                {
                    { 6, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Age Category" },
                    { 8, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Not in Desired Location" },
                    { 7, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Too Junior" },
                    { 5, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Salary Expectations Too High" },
                    { 4, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: University Type" },
                    { 3, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Qualification Type" },
                    { 2, null, "Hired Elsewhere" },
                    { 1, null, "Declined Offer" },
                    { 9, "Hi {firstname},\r\n\r\n                    Thank you for your interest in OneNebula!\r\n\r\n                    We received an overwhelming response to the {jobtitle} position, which makes us feel both humble and proud that so many talented individuals (like you!) want to join our team. This volume of response makes for an extremely competitive selection process. Although your background is impressive, we regret to inform you that we have decided to pursue other candidates for the position at this time.\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings. We hope you see another position that sparks your interest!\r\n\r\n                    Best wishes,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Does not fit ICP: Job Hopping" },
                    { 19, "Hi {firstname},\r\n\r\n                    Thank you again for your interest in OneNebula! I appreciated the opportunity we had to speak together, and I was overall impressed with your experience.\r\n\r\n                    Although your background is impressive, upon further review, we were unable to select you as an ideal fit for the position and current needs. As one of the leaders within our industry, we receive many qualified applicants like yourself, so thank you again for taking the time to apply!\r\n\r\n                    Just as we at OneNebula value our customers, we value our job candidates and invite you to review future job openings on our careers page. We hope you see another position that sparks your interest in the future and wish you the best in your career pursuits!\r\n\r\n                    Regards,\r\n                    {sentname} {sentsurname}\r\n                    {senttitle}\r\n \r\n                    OneNebula\r\n                    ", "Unsuccessful CEO Interview" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnswerTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ApplicationPhases",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "JobPlatforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobPlatforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobPlatforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobPlatforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobPlatforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UnsuccessfulReasons",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
