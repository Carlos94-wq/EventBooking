using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.Mappign
{
    public class GetVenueResponseMappgin: Profile
    {
        public GetVenueResponseMappgin()
        {
            CreateMap<Venues, GetVenueByIdResponse>();
        }
    }
}
