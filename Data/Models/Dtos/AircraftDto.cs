namespace Airline_Booking_Api.Data.Models.Dtos;

public class AircraftDto
{
    public int AircraftId { get; set; }

    public int EconomySeats { get; set; }

    public int FirstClassSeats { get; set; }

    public string AircraftType { get; set; } = null!;
}
