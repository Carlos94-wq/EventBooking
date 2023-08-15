using EvenBooking.Api.Payloads.Requests;
using EvenBooking.Api.Payloads.Responses;
using EventBooking.Application.Commands;
using EventBooking.Application.Error;
using EventBooking.Application.Querys;
using EventBooking.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvenBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/[controller]/events/{eventId}")]
        public async Task<IActionResult> RetrieveBookingsByEvent(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/api/[controller]/events")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNewBookingForEvent( [FromBody] CreateBookingRequest request) 
        {
            try
            {
                var result = await _mediator.Send(new CreateBooking.Command(request.UserId, request.EventId, request.NumberOfSeats, request.UserEmail));
                var response = new ApiResponse<bool>(result);

                return Ok(response);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("/api/[controller]/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<GetBookingsByUserIDResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookingsByUserId(int userId)
        {
            try
            {
                var result = await _mediator.Send(new GetBookingsByUserID.Query(userId));
                var apiResponse = new ApiResponse<IEnumerable<GetBookingsByUserIDResponse>>(result);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }
    }
}
