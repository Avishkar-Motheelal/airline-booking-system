using Airline_Booking_Api.Data.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Airline_Booking_Api.Utils;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(Role role)
    {
        this.Roles = role.ToString();
    }
}
