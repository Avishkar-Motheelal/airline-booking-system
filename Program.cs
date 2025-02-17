using System.Text.Json.Serialization;
using Airline_Booking_Api.Data.DbContexts;
using Airline_Booking_Api.Data.Models;
using Airline_Booking_Api.Utils;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AirlineBookingDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddApiEndpoints()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AirlineBookingDbContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.Run();
