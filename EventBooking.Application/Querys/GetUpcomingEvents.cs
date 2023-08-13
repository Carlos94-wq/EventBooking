using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Application.Responses;
using EventBooking.Domain.Interfaces;
using MediatR;

namespace EventBooking.Application.Querys
{
    public class GetUpcomingEvents
    {
        public record Query(): IRequest<IEnumerable<GetUpcomingEventsResponse>>;

        public class Handler : IRequestHandler<Query, IEnumerable<GetUpcomingEventsResponse>>
        {
            private readonly IEventsRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IEventsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetUpcomingEventsResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetUpcomingEvents();
                var upcomingEvents = _mapper.Map<IEnumerable<GetUpcomingEventsResponse>>(result);

                upcomingEvents = upcomingEvents.Select(x => new GetUpcomingEventsResponse()
                {
                    EventDate = x.EventDate,
                    EventID = x.EventID,
                    EventName = x.EventName,
                    EventStatus = x.EventDate
                        <= DateTime.Now.AddHours(2) ? "Starts soon"
                        : x.EventDate <= DateTime.Now.AddHours(0) ? "Started"
                        : x.EventDate <= DateTime.Now.AddDays(15) ? "Upcoming soon" : "Upcomming",
                    IsSelectable = x.EventDate <= DateTime.Now.AddHours(2) ? false : true,
                });

                return upcomingEvents;
            }
        }
    }

}
