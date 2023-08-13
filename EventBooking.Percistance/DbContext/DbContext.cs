using EventBooking.Domain.CustomEntities;
using EventBooking.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace EventBooking.Percistance.DbContext
{
    public class DbContext : IDbContext
    {
        private readonly DbStringConnection _stringConnection;

        public DbContext(IOptions<DbStringConnection> options)
        {
            _stringConnection = options.Value;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_stringConnection.Db);
        }
    }
}

