namespace Airline_Booking_Api.Data.Models.Dtos;

public class AirportCreateDto
{
    public string AirportName { get; set; } = null!;

    public string City { get; set; } = null!;

    public Airport ToModel()
    {
        return new()
        {
            AirportName = this.AirportName,
            City = this.City
        };
    }
}
