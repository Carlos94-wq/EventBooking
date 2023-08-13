using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;


namespace EventBooking.Application.Mappign
{
    public class GetUpcomingEventsMapping: Profile
    {
        public GetUpcomingEventsMapping()
        {
            CreateMap<Events, GetUpcomingEventsResponse>();
        }
    }
}
