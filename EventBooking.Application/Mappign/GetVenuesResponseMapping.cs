using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.Mappign
{
    public class GetVenuesResponseMapping: Profile
    {
        public GetVenuesResponseMapping()
        {
            CreateMap<Venues, GetVenuesResponse>();
        }
    }
}
