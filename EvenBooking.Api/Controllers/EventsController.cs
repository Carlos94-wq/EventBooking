using EvenBooking.Api.Payloads.Responses;
using EventBooking.Application;
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
        public async Task<IActionResult> AddNewEvent()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddNewEvent(int id)
        {
            return Ok();
        }
    }
}
