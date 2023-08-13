using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;
using System.Net;

namespace EventBooking.Application.Commands
{
    public class CreateBooking
    {
        public record Command( int UserId, int EventId, int NumberOfSeats ): IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IEventsRepository _eventsRepository;
            private readonly IMapper _mapper;

            public Handler(IBookingRepository bookingRepository, IMapper mapper, IEventsRepository eventsRepository)
            {
                _bookingRepository = bookingRepository;
                _eventsRepository = eventsRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var isEventAvailable = await _eventsRepository.GetEventDetails(request.EventId);

                if (isEventAvailable.AvailableSeats < request.NumberOfSeats)
                {
                    throw new HttpException(HttpStatusCode.BadRequest, $"{isEventAvailable.EventName} has no longer available seats");
                }

                var command = _mapper.Map<Bookings>(request);
                var isBooked = await _bookingRepository.CreaateBooking(command);

                return isBooked > 0;
            }
        }
    }
}
