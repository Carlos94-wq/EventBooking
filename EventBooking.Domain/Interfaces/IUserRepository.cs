
using EventBooking.Domain.Entities;

namespace EventBooking.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> AuthenticateUser(string UserName, string Password);
    }
}
