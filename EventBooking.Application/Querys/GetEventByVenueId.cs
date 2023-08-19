using AutoMapper;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;

namespace EventBooking.Application.Querys
{
    public class GetEventByVenueId
    {
        public record Query(int VenueId): IRequest<IEnumerable<GetEventsDetailsResponse>>;

        public class Handler : IRequestHandler<Query, IEnumerable<GetEventsDetailsResponse>>
        {
            private readonly IEventsRepository _eventsRepository;
            private readonly IMapper _mapper;

            public Handler(IEventsRepository eventsRepository, IMapper mapper)
            {
                _eventsRepository = eventsRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetEventsDetailsResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var eventsByVenue = await _eventsRepository.GetEventsByVenueId(request.VenueId);
                var mappedEvents = _mapper.Map<IEnumerable<GetEventsDetailsResponse>>(eventsByVenue);

                return mappedEvents;
            }
        }
    }
}
