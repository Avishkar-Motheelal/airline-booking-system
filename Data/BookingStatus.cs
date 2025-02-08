using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class BookingStatus
{
    public int BookingStatusId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
