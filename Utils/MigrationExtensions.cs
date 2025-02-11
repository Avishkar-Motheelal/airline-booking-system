using Airline_Booking_Api.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Airline_Booking_Api.Utils;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AirlineBookingDbContext>();
        context.Database.Migrate();
    }
}
