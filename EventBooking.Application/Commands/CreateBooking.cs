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
        public record Command( int UserId, int EventId, int NumberOfSeats, string UserEmail ): IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IEventsRepository _eventsRepository;
            private readonly IVenuesRepository _venuesRepository;
            private readonly IEmailSenderNotification _notification;
            private readonly IMapper _mapper;

            public Handler(
                    IBookingRepository bookingRepository,
                    IEventsRepository eventsRepository,
                    IEmailSenderNotification notification,
                    IMapper mapper
,                   IVenuesRepository venuesRepository
            )
            {
                _bookingRepository = bookingRepository;
                _eventsRepository = eventsRepository;
                _notification = notification;
                _mapper = mapper;
                _venuesRepository = venuesRepository;
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
                var venueDetail = await _venuesRepository.GetVenuesDetail((int)isEventAvailable.VenueID);

                if (isBooked > 0)
                {
                    await _notification.EmailSender(request.UserEmail,"Booking confirm", 
                        $"<h1>{isEventAvailable.EventName} has been booked</h1>\n\n" +
                        $"<h4>Venue: {venueDetail.VenueName}\n</h4>" +
                        $"<h4>Number of seats: {request.NumberOfSeats}\n</h4>" +
                        $"<h4>Event schedule: {isEventAvailable.EventDate}\n</h4>");
                }

                return isBooked > 0;
            }
        }
    }
}
