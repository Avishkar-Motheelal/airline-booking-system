using Airline_Booking_Api.Data.DbContexts;
using Airline_Booking_Api.Data.Enums;
using Airline_Booking_Api.Data.Models.Dtos;
using Airline_Booking_Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Route = Airline_Booking_Api.Data.Models.Route;

namespace Airline_Booking_Api.Controllers;

[Route("api/[controller]")]
[CustomAuthorize(Role.Admin)]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly AirlineBookingDbContext _context;

    public RouteController(AirlineBookingDbContext context)
    {
        this._context = context;
    }

    // GET: api/Route
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteDto>>> GetRoutes()
    {
        var routes = await this._context.Routes.ToListAsync();
        return routes.Select(route => route.ToDto()).ToList();
    }

    // GET: api/Route/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RouteDto>> GetRoute(int id)
    {
        var route = await this._context.Routes.FindAsync(id);

        if (route == null)
        {
            return this.NotFound();
        }

        return route.ToDto();
    }

    // PUT: api/Route/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoute(int id, RouteDto route)
    {
        if (id != route.RouteId)
        {
            return this.BadRequest();
        }

        var routeRecord = await this._context.Routes.FindAsync(id);

        if (routeRecord == null)
        {
            return this.NotFound();
        }

        try
        {
            routeRecord.DepartureAirport =
                await this._context.Airports.FindAsync(route.DepartureAirportId) ?? throw new();
            routeRecord.DestinationAirport =
                await this._context.Airports.FindAsync(route.DestinationAirportId) ?? throw new();
        }
        catch (Exception)
        {
            return this.BadRequest();
        }

        this._context.Entry(routeRecord).State = EntityState.Modified;

        try
        {
            await this._context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!this.RouteExists(id))
            {
                return this.NotFound();
            }

            throw;
        }

        return this.NoContent();
    }

    // POST: api/Route
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Route>> PostRoute(RouteCreateDto route)
    {
        if (route.DepartureAirportId == route.DestinationAirportId)
        {
            return this.BadRequest();
        }

        if (this.RouteExists(route.DepartureAirportId, route.DestinationAirportId))
        {
            return this.Conflict();
        }

        var createdRoute = route.ToModel();
        this._context.Routes.Add(createdRoute);
        await this._context.SaveChangesAsync();
        createdRoute = await this._context.Routes.FindAsync(createdRoute.RouteId);

        return this.CreatedAtAction("GetRoute", new { id = createdRoute.RouteId }, createdRoute.ToDto());
    }

    // DELETE: api/Route/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoute(int id)
    {
        var route = await this._context.Routes.FindAsync(id);
        if (route == null)
        {
            return this.NotFound();
        }

        this._context.Routes.Remove(route);
        await this._context.SaveChangesAsync();

        return this.NoContent();
    }

    private bool RouteExists(int id)
    {
        return this._context.Routes.Any(e => e.RouteId == id);
    }

    private bool RouteExists(int departureAirportId, int destinationAirportId)
    {
        return this._context.Routes.Any(e =>
            e.DepartureAirportId == departureAirportId && e.DestinationAirportId == destinationAirportId);
    }
}
