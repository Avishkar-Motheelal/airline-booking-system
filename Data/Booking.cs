using System;
using System.Collections.Generic;

namespace Airline_Booking_Api.Data;

public partial class Booking
{
    public int BookingId { get; set; }

    public string PaymentReference { get; set; } = null!;

    public int FlightId { get; set; }

    public int BookingStatusId { get; set; }

    public virtual BookingStatus BookingStatus { get; set; } = null!;

    public virtual Flight Flight { get; set; } = null!;

    public virtual ICollection<PassengerBooking> PassengerBookings { get; set; } = new List<PassengerBooking>();
}
