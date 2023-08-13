using EventBooking.Domain.Entities;

namespace EvenBooking.Api.Payloads.Responses
{
    public record LogUserResponse(Users User, string token);
}
