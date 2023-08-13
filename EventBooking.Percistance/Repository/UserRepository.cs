using Dapper;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using System.Data;

namespace EventBooking.Percistance.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> AuthenticateUser(string UserName, string Password)
        {
            using (var conn = _dbContext.GetDbConnection())
            {
                var parameters = new
                {
                    @Username = UserName,
                    @Password = Password
                };
                var user = await conn.QueryAsync<Users>("AuthenticateUser",parameters, commandType: CommandType.StoredProcedure);

                return user.FirstOrDefault();
            }
        }
    }
}
