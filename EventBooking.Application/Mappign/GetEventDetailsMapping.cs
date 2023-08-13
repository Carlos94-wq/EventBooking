using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.Mappign
{
    public class GetEventDetailsMapping: Profile
    {
        public GetEventDetailsMapping()
        {
            CreateMap<Events, GetEventsDetailsResponse>();
        }
    }
}
