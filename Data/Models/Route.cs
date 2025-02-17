using Airline_Booking_Api.Data.Models.Dtos;

namespace Airline_Booking_Api.Data.Models;

public class Route
{
    public int RouteId { get; set; }

    public int DepartureAirportId { get; set; }

    public int DestinationAirportId { get; set; }

    public virtual Airport DepartureAirport { get; set; } = null!;

    public virtual Airport DestinationAirport { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public RouteDto ToDto()
    {
        return new()
        {
            RouteId = this.RouteId,
            DepartureAirportId = this.DepartureAirportId,
            DestinationAirportId = this.DestinationAirportId
        };
    }
}
