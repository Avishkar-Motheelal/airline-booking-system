using Airline_Booking_Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline_Booking_Api.Data.SeedConfiguration;

public class FlightStatusSeeder : IEntityTypeConfiguration<FlightStatus>
{
    public void Configure(EntityTypeBuilder<FlightStatus> builder)
    {
        builder.HasData(
            new FlightStatus
            {
                FlightStatusId = 1,
                Status = "Scheduled"
            },
            new FlightStatus
            {
                FlightStatusId = 2,
                Status = "Boarding"
            },
            new FlightStatus
            {
                FlightStatusId = 3,
                Status = "Departed"
            },
            new FlightStatus
            {
                FlightStatusId = 4,
                Status = "Arrived"
            },
            new FlightStatus
            {
                FlightStatusId = 5,
                Status = "Cancelled"
            },
            new FlightStatus
            {
                FlightStatusId = 6,
                Status = "Delayed"
            });
    }
}
