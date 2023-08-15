using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.Mappign
{
    public class GetBookingEventsByUserIdMappgin: Profile
    {
        public GetBookingEventsByUserIdMappgin()
        {
            CreateMap<Bookings, GetBookingsByUserIDResponse>();
        }
    }
}
