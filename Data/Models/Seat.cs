namespace Airline_Booking_Api.Data.Models;

public class Seat
{
    public int SeatId { get; set; }

    public int SeatNumber { get; set; }

    public string SeatRow { get; set; } = null!;

    public int AircraftId { get; set; }

    public virtual Aircraft Aircraft { get; set; } = null!;
}