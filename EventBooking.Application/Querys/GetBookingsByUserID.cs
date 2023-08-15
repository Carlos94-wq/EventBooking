using AutoMapper;
using EventBooking.Application.Error;
using EventBooking.Application.Responses;
using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Querys
{
    public class GetBookingsByUserID
    {
        public record Query(int UserId):IRequest<IEnumerable<GetBookingsByUserIDResponse>>;

        public class Handler : IRequestHandler<Query, IEnumerable<GetBookingsByUserIDResponse>>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IEventsRepository _eventsRepository;
            private readonly IVenuesRepository _venuesRepository;
            private readonly IMapper _mapper;

            public Handler(
                   IBookingRepository bookingRepository, 
                   IEventsRepository eventsRepository, 
                   IVenuesRepository venuesRepository, 
                   IMapper mapper)
            {
                _bookingRepository = bookingRepository;
                _eventsRepository = eventsRepository;
                _venuesRepository = venuesRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetBookingsByUserIDResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bookingsByUser = await _bookingRepository.GetBookingsByUserId(request.UserId);

                if (bookingsByUser is null)
                {
                    throw new HttpException(HttpStatusCode.NotFound, "User has not booked events");
                }

                var mappedResult = _mapper.Map<IEnumerable<GetBookingsByUserIDResponse>>(bookingsByUser);
                foreach (var item in mappedResult)
                {
                    item.Events = await _eventsRepository.GetEventDetails((int)item.EventID);
                    item.Venues = await _venuesRepository.GetVenuesDetail((int)item.Events.VenueID);
                }

                return mappedResult;
            }
        }
    }
}
