namespace Airline_Booking_Api.Data.Models;

public class BookingStatus
{
    public int BookingStatusId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}