using XebecAPI.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Configurations
{
    public class AnswerTypeConfiguration : IEntityTypeConfiguration<AnswerType>
    {
        public void Configure(EntityTypeBuilder<AnswerType> builder)
        {
            builder.HasData(
                new AnswerType
                {
                    Id = 1,
                    Type = "Number"
                },
                new AnswerType
                {
                    Id = 2,
                    Type = "Long Text"
                },
                new AnswerType
                {
                    Id = 3,
                    Type = "Short Text"
                },
                 new AnswerType
                 {
                     Id = 4,
                     Type = "Date/Time"
                 },
                 new AnswerType
                 {
                     Id = 5,
                     Type = "Boolean"
                 },
                new AnswerType
                {
                    Id = 6,
                    Type = "File Upload"
                },
                 new AnswerType
                 {
                     Id = 7,
                     Type = "Hybrid"
                 });
        }
    }
}
