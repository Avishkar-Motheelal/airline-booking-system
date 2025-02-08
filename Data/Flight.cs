using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class Flight
{
    public int FlightId { get; set; }

    public int RouteId { get; set; }

    public DateTime TripDate { get; set; }

    public int FlightStatusId { get; set; }

    public int AircraftId { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual FlightStatus FlightStatus { get; set; } = null!;

    public virtual Route Route { get; set; } = null!;
}
