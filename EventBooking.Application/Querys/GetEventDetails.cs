using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Application.Responses;
using EventBooking.Domain.Interfaces;
using MediatR;
using System.Net;

namespace EventBooking.Application.Querys
{
    public class GetEventDetails
    {
        public record Query(int EventID): IRequest<GetEventsDetailsResponse>;

        public class Handler : IRequestHandler<Query, GetEventsDetailsResponse>
        {
            private readonly IEventsRepository _eventsRepository;
            private readonly IVenuesRepository _venuesRepository;
            private readonly IMapper _mapper;

            public Handler(IEventsRepository eventsRepository, IMapper mapper, IVenuesRepository venuesRepository)
            { 
                _eventsRepository = eventsRepository;
                _venuesRepository = venuesRepository;
                _mapper = mapper;
            }

            public async Task<GetEventsDetailsResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var eventDetails = await _eventsRepository.GetEventDetails(request.EventID);
                if (eventDetails is null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "Event no found");
                }

                var venueDetails = await _venuesRepository.GetVenuesDetail((int)eventDetails.VenueID);
                var resultResponse = _mapper.Map<GetEventsDetailsResponse>(eventDetails);
                var getVenueByIdResponse = _mapper.Map<GetVenueByIdResponse>(venueDetails);

                resultResponse.VenueDetails = getVenueByIdResponse;

                return resultResponse;
            }
        }
    }
}
