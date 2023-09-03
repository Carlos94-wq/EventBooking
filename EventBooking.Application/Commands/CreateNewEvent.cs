using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;

namespace EventBooking.Application.Commands
{
    public class CreateNewEvent
    {
        public record Command(string EventName, DateTime EventDate, int VenueID, int AvailableSeats): IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IEventsRepository _eventsRepository;
            private readonly IMapper _mapper;

            public Handler(IEventsRepository eventsRepository, IMapper mapper)
            {
                _eventsRepository = eventsRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var mappedRequest = _mapper.Map<Events>(request);
                var isAdded = await _eventsRepository.AddEvent(mappedRequest);

                if (isAdded < 0)
                {
                    throw new HttpException(System.Net.HttpStatusCode.BadRequest, "No events registered");
                }

                return isAdded > 0;
            }
        }
    }
}
