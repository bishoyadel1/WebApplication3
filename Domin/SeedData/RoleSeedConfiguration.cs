﻿ 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.SeedData
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                },
                new IdentityRole
                {
                    Id = "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                    Name ="User",
                    NormalizedName = "User".ToUpper()
                }
            );
          }
    }
}
