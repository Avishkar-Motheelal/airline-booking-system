using Airline_Booking_Api.Data.DbContexts;
using Airline_Booking_Api.Data.Enums;
using Airline_Booking_Api.Data.Models;
using Airline_Booking_Api.Data.Models.Dtos;
using Airline_Booking_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airline_Booking_Api.Controllers;

[Route("api/[controller]")]
[CustomAuthorize(Role.Admin)]
[ApiController]
public class AirportController : ControllerBase
{
    private readonly AirlineBookingDbContext _context;

    public AirportController(AirlineBookingDbContext context)
    {
        this._context = context;
    }

    // GET: api/Airport
    [AllowAnonymous]
    [HttpGet]
    public async Task<List<AirportDto>> GetAirports()
    {
        var airports = await this._context.Airports.ToListAsync();
        return airports.Select(airport => airport.ToDto()).ToList();
    }

    // GET: api/Airport/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AirportDto>> GetAirport(int id)
    {
        var airport = await this._context.Airports.FindAsync(id);

        if (airport == null)
        {
            return this.NotFound();
        }

        return airport.ToDto();
    }

    // PUT: api/Airport/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAirport(int id, Airport airport)
    {
        if (id != airport.AirportId)
        {
            return this.BadRequest();
        }

        this._context.Entry(airport).State = EntityState.Modified;

        try
        {
            await this._context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!this.AirportExists(id))
            {
                return this.NotFound();
            }

            throw;
        }

        return this.NoContent();
    }

    // POST: api/Airport
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Airport>> PostAirport(AirportCreateDto airport)
    {
        var createdAirport = airport.ToModel();
        this._context.Airports.Add(createdAirport);
        await this._context.SaveChangesAsync();

        return this.CreatedAtAction("GetAirport", new { id = createdAirport.AirportId }, createdAirport.ToDto());
    }

    // DELETE: api/Airport/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int id)
    {
        var airport = await this._context.Airports.FindAsync(id);
        if (airport == null)
        {
            return this.NotFound();
        }

        this._context.Airports.Remove(airport);
        await this._context.SaveChangesAsync();

        return this.NoContent();
    }

    private bool AirportExists(int id)
    {
        return this._context.Airports.Any(e => e.AirportId == id);
    }
}
