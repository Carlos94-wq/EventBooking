using EventBooking.Domain.CustomEntities;
using EventBooking.Domain.Interfaces;
using EventBooking.Percistance.DbContext;
using EventBooking.Percistance.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBooking.Application.Extenssions
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<DbStringConnection>(configuration.GetSection("ConnectionStrings"));
            services.Configure<TokenConfigure>(configuration.GetSection("tokenManagement"));

            services.AddTransient<IDbContext, DbContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventsRepository, EventsRepository>();        
            services.AddTransient<IVenuesRepository, VenuesRespository>();        
            services.AddTransient<IBookingRepository, BookingRepository>();        

            return services;
        }
    }
}
