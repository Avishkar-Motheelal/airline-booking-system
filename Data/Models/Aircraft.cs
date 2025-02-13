using Airline_Booking_Api.Data.Models.Dtos;

namespace Airline_Booking_Api.Data.Models;

public class Aircraft
{
    public int AircraftId { get; set; }

    public int EconomySeats { get; set; }

    public int FirstClassSeats { get; set; }

    public string AircraftType { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public AircraftDto ToDto()
    {
        return new()
        {
            AircraftId = this.AircraftId,
            EconomySeats = this.EconomySeats,
            FirstClassSeats = this.FirstClassSeats,
            AircraftType = this.AircraftType
        };
    }
}
