using XebecAPI.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Configurations
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.HasData(
                new AnswerType
                {
                    Id = 1,
                    Type = "Freelance"
                },
                new AnswerType
                {
                    Id = 2,
                    Type = "Full Time"
                },
                new AnswerType
                {
                    Id = 3,
                    Type = "Part Time"
                },
                 new AnswerType
                 {
                     Id = 4,
                     Type = "Contract"
                 },
                 new AnswerType
                 {
                     Id = 5,
                     Type = "Temporary"
                 },
                new AnswerType
                {
                    Id = 6,
                    Type = "Internship"
                });
        }
    }
}
