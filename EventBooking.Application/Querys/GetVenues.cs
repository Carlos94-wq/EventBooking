using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Application.Responses;
using EventBooking.Domain.Interfaces;
using MediatR;
using System.Net;

namespace EventBooking.Application.Querys
{
    public class GetVenues
    {
        public record Query( string VenueName, string Address ): IRequest<IEnumerable<GetVenuesResponse>>;

        public class Handler : IRequestHandler<Query, IEnumerable<GetVenuesResponse>>
        {
            private readonly IVenuesRepository _venuesRepository;
            private readonly IEventsRepository _eventsRepository;
            private readonly IMapper _mapper;

            public Handler(IVenuesRepository venuesRepository, IMapper mapper, IEventsRepository eventsRepository)
            {
                _venuesRepository = venuesRepository;            
                _eventsRepository = eventsRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetVenuesResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var venuesResult = await _venuesRepository.GetVenue(request.VenueName, request.Address);
                var mappedResponse = _mapper.Map<IEnumerable<GetVenuesResponse>>(venuesResult);

                if (mappedResponse is null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "No Venues found");
                }

                foreach (var item in mappedResponse)
                {
                    var eventsByVenue = await _eventsRepository.GetEventsByVenueId(item.VenueID);
                    var mappedEvents = _mapper.Map<IEnumerable<GetEventsDetailsResponse>>(eventsByVenue);

                    item.Events = mappedEvents;
                }

                

                return mappedResponse;
            }
        }
    }
}
