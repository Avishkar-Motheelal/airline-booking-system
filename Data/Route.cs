using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class Route
{
    public int RouteId { get; set; }

    public int DepartureAirportId { get; set; }

    public int DestinationAirportId { get; set; }

    public virtual Airport DepartureAirport { get; set; } = null!;

    public virtual Airport DestinationAirport { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
