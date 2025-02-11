namespace Airline_Booking_Api.Data.Models;

public class PassengerDetail
{
    public int PassengerDetailId { get; set; }

    public string FirstNames { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public int Age { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<PassengerBooking> PassengerBookings { get; set; } = new List<PassengerBooking>();
}