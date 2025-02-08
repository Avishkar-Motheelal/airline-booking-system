using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class PassengerBooking
{
    public int PassengerBookingId { get; set; }

    public int PassengerDetailId { get; set; }

    public int BookingId { get; set; }

    public bool CheckedIn { get; set; }

    public int? SeatId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual PassengerDetail PassengerDetail { get; set; } = null!;
}
