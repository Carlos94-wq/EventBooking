using EventBooking.Domain.Interfaces;
using MediatR;

namespace EventBooking.Application.Commands
{
    public class CancelBookingByBookingId
    {
        public record Command(int BookingId) : IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IBookingRepository _bookingRepository;

            public Handler(IBookingRepository bookingRepository)
            {
                _bookingRepository = bookingRepository;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var isCanceled = await _bookingRepository.CanelBookingsByBookingId(request.BookingId);
                return isCanceled > 0;
            }
        }
    }
}
