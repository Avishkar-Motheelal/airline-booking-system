﻿// <auto-generated />
using System;
using Airline_Booking_Api.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Airline_Booking_Api.Migrations
{
    [DbContext(typeof(AirlineBookingDbContext))]
    partial class AirlineBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("aircraft_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AircraftId"));

                    b.Property<string>("AircraftType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("aircraft_type");

                    b.Property<int>("EconomySeats")
                        .HasColumnType("int")
                        .HasColumnName("economy_seats");

                    b.Property<int>("FirstClassSeats")
                        .HasColumnType("int")
                        .HasColumnName("first_class_seats");

                    b.HasKey("AircraftId")
                        .HasName("PK__aircraft__04015399335624B0");

                    b.ToTable("aircraft", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Airport", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("airport_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirportId"));

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("airport_name");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.HasKey("AirportId")
                        .HasName("PK__airports__C795D51665A10608");

                    b.ToTable("airports", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("booking_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int")
                        .HasColumnName("booking_status_id");

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    b.Property<string>("PaymentReference")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("payment_reference");

                    b.HasKey("BookingId")
                        .HasName("PK__bookings__5DE3A5B1B2E253FC");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("FlightId");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.BookingStatus", b =>
                {
                    b.Property<int>("BookingStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("booking_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingStatusId"));

                    b.Property<string>("Status")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.HasKey("BookingStatusId")
                        .HasName("PK__booking___B02F4E9E753FAF84");

                    b.ToTable("booking_statuses", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<int>("AircraftId")
                        .HasColumnType("int")
                        .HasColumnName("aircraft_id");

                    b.Property<int>("FlightStatusId")
                        .HasColumnType("int")
                        .HasColumnName("flight_status_id");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<DateTime>("TripDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("trip_date");

                    b.HasKey("FlightId")
                        .HasName("PK__flights__E370576593A1E372");

                    b.HasIndex("AircraftId");

                    b.HasIndex("FlightStatusId");

                    b.HasIndex("RouteId");

                    b.ToTable("flights", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.FlightStatus", b =>
                {
                    b.Property<int>("FlightStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flight_status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightStatusId"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.HasKey("FlightStatusId")
                        .HasName("PK__flight_s__C09C73A49D814091");

                    b.ToTable("flight_statuses", (string)null);

                    b.HasData(
                        new
                        {
                            FlightStatusId = 1,
                            Status = "Scheduled"
                        },
                        new
                        {
                            FlightStatusId = 2,
                            Status = "Boarding"
                        },
                        new
                        {
                            FlightStatusId = 3,
                            Status = "Departed"
                        },
                        new
                        {
                            FlightStatusId = 4,
                            Status = "Arrived"
                        },
                        new
                        {
                            FlightStatusId = 5,
                            Status = "Cancelled"
                        },
                        new
                        {
                            FlightStatusId = 6,
                            Status = "Delayed"
                        });
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.PassengerBooking", b =>
                {
                    b.Property<int>("PassengerBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("passenger_booking_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerBookingId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int")
                        .HasColumnName("booking_id");

                    b.Property<bool>("CheckedIn")
                        .HasColumnType("bit")
                        .HasColumnName("checked_in");

                    b.Property<int>("PassengerDetailId")
                        .HasColumnType("int")
                        .HasColumnName("passenger_detail_id");

                    b.Property<int?>("SeatId")
                        .HasColumnType("int")
                        .HasColumnName("seat_id");

                    b.HasKey("PassengerBookingId")
                        .HasName("PK__passenge__56C35897474DD112");

                    b.HasIndex("BookingId");

                    b.HasIndex("PassengerDetailId");

                    b.ToTable("passenger_booking", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.PassengerDetail", b =>
                {
                    b.Property<int>("PassengerDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("passenger_detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerDetailId"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("contact_number");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email_address");

                    b.Property<string>("FirstNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_names");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("id_number");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.HasKey("PassengerDetailId")
                        .HasName("PK__passenge__D3BCE376D4680FD9");

                    b.ToTable("passenger_details", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int")
                        .HasColumnName("departure_airport_id");

                    b.Property<int>("DestinationAirportId")
                        .HasColumnType("int")
                        .HasColumnName("destination_airport_id");

                    b.HasKey("RouteId")
                        .HasName("PK__routes__28F706FE2C1429E6");

                    b.HasIndex("DepartureAirportId");

                    b.HasIndex("DestinationAirportId");

                    b.ToTable("routes", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("seat_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<int>("AircraftId")
                        .HasColumnType("int")
                        .HasColumnName("aircraft_id");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int")
                        .HasColumnName("seat_number");

                    b.Property<string>("SeatRow")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("seat_row");

                    b.HasKey("SeatId")
                        .HasName("PK__seats__906DED9C6DD5B1C5");

                    b.HasIndex("AircraftId");

                    b.ToTable("seats", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e61805d8-4fd2-4e15-8e72-6212a3131b44",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "93884451-cd0e-46d5-8358-6630c6bd421d",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Booking", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .IsRequired()
                        .HasConstraintName("FK__bookings__bookin__4D94879B");

                    b.HasOne("Airline_Booking_Api.Data.Models.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("FK__bookings__flight__4CA06362");

                    b.Navigation("BookingStatus");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Flight", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AircraftId")
                        .IsRequired()
                        .HasConstraintName("FK__flights__aircraf__4AB81AF0");

                    b.HasOne("Airline_Booking_Api.Data.Models.FlightStatus", "FlightStatus")
                        .WithMany("Flights")
                        .HasForeignKey("FlightStatusId")
                        .IsRequired()
                        .HasConstraintName("FK__flights__flight___49C3F6B7");

                    b.HasOne("Airline_Booking_Api.Data.Models.Route", "Route")
                        .WithMany("Flights")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK__flights__route_i__4BAC3F29");

                    b.Navigation("Aircraft");

                    b.Navigation("FlightStatus");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.PassengerBooking", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.Booking", "Booking")
                        .WithMany("PassengerBookings")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK__passenger__booki__5EBF139D");

                    b.HasOne("Airline_Booking_Api.Data.Models.PassengerDetail", "PassengerDetail")
                        .WithMany("PassengerBookings")
                        .HasForeignKey("PassengerDetailId")
                        .IsRequired()
                        .HasConstraintName("FK__passenger__passe__60A75C0F");

                    b.Navigation("Booking");

                    b.Navigation("PassengerDetail");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Route", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.Airport", "DepartureAirport")
                        .WithMany("RouteDepartureAirports")
                        .HasForeignKey("DepartureAirportId")
                        .IsRequired()
                        .HasConstraintName("FK__routes__departur__47DBAE45");

                    b.HasOne("Airline_Booking_Api.Data.Models.Airport", "DestinationAirport")
                        .WithMany("RouteDestinationAirports")
                        .HasForeignKey("DestinationAirportId")
                        .IsRequired()
                        .HasConstraintName("FK__routes__destinat__48CFD27E");

                    b.Navigation("DepartureAirport");

                    b.Navigation("DestinationAirport");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Seat", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.Aircraft", "Aircraft")
                        .WithMany("Seats")
                        .HasForeignKey("AircraftId")
                        .IsRequired()
                        .HasConstraintName("FK__seats__aircraft___46E78A0C");

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Airline_Booking_Api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Airline_Booking_Api.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Aircraft", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Airport", b =>
                {
                    b.Navigation("RouteDepartureAirports");

                    b.Navigation("RouteDestinationAirports");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Booking", b =>
                {
                    b.Navigation("PassengerBookings");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Flight", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.FlightStatus", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.PassengerDetail", b =>
                {
                    b.Navigation("PassengerBookings");
                });

            modelBuilder.Entity("Airline_Booking_Api.Data.Models.Route", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
