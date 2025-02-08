using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class Airport
{
    public int AirportId { get; set; }

    public string AirportName { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Route> RouteDepartureAirports { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteDestinationAirports { get; set; } = new List<Route>();
}
