using XebecAPI.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XebecAPI.Configurations
{
    public class JobPlatformConfiguration : IEntityTypeConfiguration<JobPlatform>
    {
        public void Configure(EntityTypeBuilder<JobPlatform> builder)
        {
            builder.HasData(
                new JobPlatform
                {
                    Id = 1,
                    PlatformName = "Main 1Nebula Platform"
                },
                new JobPlatform
                {
                    Id = 2,
                    PlatformName = "Xebec Platform"
                },
                new JobPlatform
                {
                    Id = 3,
                    PlatformName = "48Software"
                },
                 new JobPlatform
                 {
                     Id = 4,
                     PlatformName = "Oneview"
                 },
                  new JobPlatform
                  {
                      Id = 5,
                      PlatformName = "Stactize"
                  });
        }
    }
}
