namespace Airline_Booking_Api.Data.Models.Dtos;

public class AircraftCreateDto
{
    public int EconomySeats { get; set; }

    public int FirstClassSeats { get; set; }

    public string AircraftType { get; set; } = null!;

    public Aircraft ToAircraft()
    {
        return new()
        {
            EconomySeats = this.EconomySeats,
            FirstClassSeats = this.FirstClassSeats,
            AircraftType = this.AircraftType
        };
    }
}
