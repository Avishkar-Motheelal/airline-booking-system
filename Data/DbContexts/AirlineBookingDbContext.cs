using Airline_Booking_Api.Data.Models;
using Airline_Booking_Api.Data.SeedConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route = Airline_Booking_Api.Data.Models.Route;

namespace Airline_Booking_Api.Data.DbContexts;

public partial class AirlineBookingDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public AirlineBookingDbContext()
    {
    }

    public AirlineBookingDbContext(DbContextOptions<AirlineBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aircraft> Aircraft { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingStatus> BookingStatuses { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightStatus> FlightStatuses { get; set; }

    public virtual DbSet<PassengerBooking> PassengerBookings { get; set; }

    public virtual DbSet<PassengerDetail> PassengerDetails { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleSeeder());

        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.AircraftId).HasName("PK__aircraft__04015399335624B0");

            entity.ToTable("aircraft");

            entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");
            entity.Property(e => e.AircraftType)
                .HasMaxLength(255)
                .HasColumnName("aircraft_type");
            entity.Property(e => e.EconomySeats).HasColumnName("economy_seats");
            entity.Property(e => e.FirstClassSeats).HasColumnName("first_class_seats");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK__airports__C795D51665A10608");

            entity.ToTable("airports");

            entity.Property(e => e.AirportId).HasColumnName("airport_id");
            entity.Property(e => e.AirportName).HasColumnName("airport_name");
            entity.Property(e => e.City).HasColumnName("city");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__bookings__5DE3A5B1B2E253FC");

            entity.ToTable("bookings");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookingStatusId).HasColumnName("booking_status_id");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.PaymentReference)
                .IsUnicode(false)
                .HasColumnName("payment_reference");

            entity.HasOne(d => d.BookingStatus).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookingStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookings__bookin__4D94879B");

            entity.HasOne(d => d.Flight).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookings__flight__4CA06362");
        });

        modelBuilder.Entity<BookingStatus>(entity =>
        {
            entity.HasKey(e => e.BookingStatusId).HasName("PK__booking___B02F4E9E753FAF84");

            entity.ToTable("booking_statuses");

            entity.Property(e => e.BookingStatusId).HasColumnName("booking_status_id");
            entity.Property(e => e.Status)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__flights__E370576593A1E372");

            entity.ToTable("flights");

            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");
            entity.Property(e => e.FlightStatusId).HasColumnName("flight_status_id");
            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.TripDate).HasColumnName("trip_date");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights__aircraf__4AB81AF0");

            entity.HasOne(d => d.FlightStatus).WithMany(p => p.Flights)
                .HasForeignKey(d => d.FlightStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights__flight___49C3F6B7");

            entity.HasOne(d => d.Route).WithMany(p => p.Flights)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__flights__route_i__4BAC3F29");
        });

        modelBuilder.Entity<FlightStatus>(entity =>
        {
            entity.HasKey(e => e.FlightStatusId).HasName("PK__flight_s__C09C73A49D814091");

            entity.ToTable("flight_statuses");

            entity.Property(e => e.FlightStatusId).HasColumnName("flight_status_id");
            entity.Property(e => e.Status)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<PassengerBooking>(entity =>
        {
            entity.HasKey(e => e.PassengerBookingId).HasName("PK__passenge__56C35897474DD112");

            entity.ToTable("passenger_booking");

            entity.Property(e => e.PassengerBookingId).HasColumnName("passenger_booking_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CheckedIn).HasColumnName("checked_in");
            entity.Property(e => e.PassengerDetailId).HasColumnName("passenger_detail_id");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.PassengerBookings)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__passenger__booki__5EBF139D");

            entity.HasOne(d => d.PassengerDetail).WithMany(p => p.PassengerBookings)
                .HasForeignKey(d => d.PassengerDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__passenger__passe__60A75C0F");
        });

        modelBuilder.Entity<PassengerDetail>(entity =>
        {
            entity.HasKey(e => e.PassengerDetailId).HasName("PK__passenge__D3BCE376D4680FD9");

            entity.ToTable("passenger_details");

            entity.Property(e => e.PassengerDetailId).HasColumnName("passenger_detail_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ContactNumber)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.EmailAddress).HasColumnName("email_address");
            entity.Property(e => e.FirstNames).HasColumnName("first_names");
            entity.Property(e => e.IdNumber).HasColumnName("id_number");
            entity.Property(e => e.LastName).HasColumnName("last_name");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__routes__28F706FE2C1429E6");

            entity.ToTable("routes");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.DepartureAirportId).HasColumnName("departure_airport_id");
            entity.Property(e => e.DestinationAirportId).HasColumnName("destination_airport_id");

            entity.HasOne(d => d.DepartureAirport).WithMany(p => p.RouteDepartureAirports)
                .HasForeignKey(d => d.DepartureAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__routes__departur__47DBAE45");

            entity.HasOne(d => d.DestinationAirport).WithMany(p => p.RouteDestinationAirports)
                .HasForeignKey(d => d.DestinationAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__routes__destinat__48CFD27E");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__seats__906DED9C6DD5B1C5");

            entity.ToTable("seats");

            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.AircraftId).HasColumnName("aircraft_id");
            entity.Property(e => e.SeatNumber).HasColumnName("seat_number");
            entity.Property(e => e.SeatRow)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("seat_row");

            entity.HasOne(d => d.Aircraft).WithMany(p => p.Seats)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__seats__aircraft___46E78A0C");
        });

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
