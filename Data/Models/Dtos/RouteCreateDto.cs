namespace Airline_Booking_Api.Data.Models.Dtos;

public class RouteCreateDto
{
    public int DepartureAirportId { get; set; }

    public int DestinationAirportId { get; set; }

    public Route ToModel()
    {
        return new()
        {
            DepartureAirportId = this.DepartureAirportId,
            DestinationAirportId = this.DestinationAirportId
        };
    }
}
