using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class FlightStatus
{
    public int FlightStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
