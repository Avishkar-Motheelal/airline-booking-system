using Airline_Booking_Api.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline_Booking_Api.Data.SeedConfiguration;

public class RoleSeeder : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "e61805d8-4fd2-4e15-8e72-6212a3131b44",
                Name = Role.Admin.ToString(),
                NormalizedName = Role.Admin.ToString().ToUpper()
            },
            new IdentityRole
            {
                Id = "93884451-cd0e-46d5-8358-6630c6bd421d",
                Name = Role.User.ToString(),
                NormalizedName = Role.User.ToString().ToUpper()
            }
        );
    }
}
