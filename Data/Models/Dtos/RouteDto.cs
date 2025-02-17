namespace Airline_Booking_Api.Data.Models.Dtos;

public class RouteDto
{
    public int RouteId { get; set; }

    public int DepartureAirportId { get; set; }

    public int DestinationAirportId { get; set; }
}
