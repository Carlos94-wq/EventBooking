using AutoMapper;
using EventBooking.Application.Commands;
using EventBooking.Domain.Entities;

namespace EventBooking.Application.Mappign
{
    public class CreateNewEventMapping: Profile
    {
        public CreateNewEventMapping()
        {
            CreateMap<CreateNewEvent.Command, Events>();
        }
    }
}
