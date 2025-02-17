namespace Airline_Booking_Api.Data.Models.Dtos;

public class AirportDto
{
    public int AirportId { get; set; }

    public string AirportName { get; set; } = null!;

    public string City { get; set; } = null!;
}
