using Airline_Booking_Api.Data.DbContexts;
using Airline_Booking_Api.Data.Enums;
using Airline_Booking_Api.Data.Models;
using Airline_Booking_Api.Data.Models.Dtos;
using Airline_Booking_Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline_Booking_Api.Controllers;

[Route("api/[controller]")]
[CustomAuthorize(Role.Admin)]
[ApiController]
public class AircraftController : ControllerBase
{
    private readonly AirlineBookingDbContext _context;

    public AircraftController(AirlineBookingDbContext context)
    {
        this._context = context;
    }

    // GET: api/Aircraft
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AircraftDto>>> GetAircraft()
    {
        var aircraft = await this._context.Aircraft.ToListAsync();
        return aircraft.Select(x => x.ToDto()).ToList();
    }

    // GET: api/Aircraft/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AircraftDto>> GetAircraft(int id)
    {
        var aircraft = await this._context.Aircraft.FindAsync(id);

        if (aircraft == null)
        {
            return this.NotFound();
        }

        return aircraft.ToDto();
    }

    // PUT: api/Aircraft/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAircraft(int id, Aircraft aircraft)
    {
        if (id != aircraft.AircraftId)
        {
            return this.BadRequest();
        }

        this._context.Entry(aircraft).State = EntityState.Modified;

        try
        {
            await this._context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!this.AircraftExists(id))
            {
                return this.NotFound();
            }

            throw;
        }

        return this.NoContent();
    }

    // POST: api/Aircraft
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Aircraft>> PostAircraft(AircraftCreateDto aircraftDto)
    {
        var aircraft = aircraftDto.ToAircraft();
        this._context.Aircraft.Add(aircraft);

        this.GenerateSeats(ref aircraft);

        await this._context.SaveChangesAsync();

        return this.CreatedAtAction("GetAircraft", new { id = aircraft.AircraftId }, aircraft);
    }

    private void GenerateSeats(ref Aircraft aircraft)
    {
        var seats = new List<Seat>();
        for (var i = 1; i <= aircraft.EconomySeats; i++)
            seats.Add(new()
            {
                AircraftId = aircraft.AircraftId,
                SeatNumber = i,
                SeatRow = "B"
            });

        for (var i = 1; i <= aircraft.FirstClassSeats; i++)
            seats.Add(new()
            {
                AircraftId = aircraft.AircraftId,
                SeatNumber = i,
                SeatRow = "A"
            });

        aircraft.Seats = seats;
    }

    // DELETE: api/Aircraft/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAircraft(int id)
    {
        var aircraft = await this._context.Aircraft.FindAsync(id);
        if (aircraft == null)
        {
            return this.NotFound();
        }

        this._context.Aircraft.Remove(aircraft);
        await this._context.SaveChangesAsync();

        return this.NoContent();
    }

    private bool AircraftExists(int id)
    {
        return this._context.Aircraft.Any(e => e.AircraftId == id);
    }
}
