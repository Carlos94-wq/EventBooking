using EvenBooking.Api.Payloads.Requests;
using EvenBooking.Api.Payloads.Responses;
using EventBooking.Application;
using EventBooking.Application.Commands;
using EventBooking.Application.Error;
using EventBooking.Application.Querys;
using EventBooking.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/[controller]/upcoming")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetUpcomingEventsResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetrieveUpcomingEvents()
        {
            try
            {
                var result = await _mediator.Send(new GetUpcomingEvents.Query());
                var response = new ApiResponse<IEnumerable<GetUpcomingEventsResponse>>(result);

                return Ok(response);
            }
            catch (HttpException e) 
            {
                throw e;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewEvent([FromBody] NewEventRequest request)
        {
            try
            {
                var result = await _mediator.Send(new CreateNewEvent.Command(
                    request.EventName,
                    request.EventDate,
                    request.VenueID,
                    request.AvailableSeats
                ));
                var apiResponse = new ApiResponse<bool>(result);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddNewEvent(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/api/[controller]/details/{id}")]
        [ProducesResponseType(typeof(ApiResponse<GetEventsDetailsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetrieveEventDetails(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetEventDetails.Query(id));
                var response = new ApiResponse<GetEventsDetailsResponse>(result);

                return Ok(response);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewEvent_1([FromBody] NewEventRequest request)
        {
            try
            {
                var result = await _mediator.Send(new CreateNewEvent.Command(
                    request.EventName,
                    request.EventDate,
                    request.VenueID,
                    request.AvailableSeats
                ));
                var apiResponse = new ApiResponse<bool>(result);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddNewEvent_2(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewEvent_3([FromBody] NewEventRequest request)
        {
            try
            {
                var result = await _mediator.Send( new CreateNewEvent.Command(
                    request.EventName, 
                    request.EventDate, 
                    request.VenueID, 
                    request.AvailableSeats
                ));
                var apiResponse = new ApiResponse<bool>(result);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddNewEvent_4(int id)
        {
            return Ok();
        }
    }
}
