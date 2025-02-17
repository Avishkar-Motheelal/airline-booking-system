using Airline_Booking_Api.Data.Models.Dtos;

namespace Airline_Booking_Api.Data.Models;

public class Airport
{
    public int AirportId { get; set; }

    public string AirportName { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Route> RouteDepartureAirports { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteDestinationAirports { get; set; } = new List<Route>();

    public AirportDto ToDto()
    {
        return new()
        {
            AirportId = this.AirportId,
            AirportName = this.AirportName,
            City = this.City
        };
    }
}
