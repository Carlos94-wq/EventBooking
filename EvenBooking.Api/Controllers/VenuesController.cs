using EvenBooking.Api.Payloads.Responses;
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
    public class VenuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/[controller]")]
        public async Task<IActionResult> RetrieveVenues([FromQuery] string? venueName, string? adderss)
        {

            try
            {
                var result = await _mediator.Send( new GetVenues.Query(venueName, adderss) );
                var apiResponse = new ApiResponse<IEnumerable<GetVenuesResponse>>(result);

                return Ok(apiResponse);
            }
            catch (HttpException e)
            {
                throw e;
            }
        }

        [HttpGet]
        [Route("/api/[controller]/details/{id}")]
        public async Task<IActionResult> RetrieveVenueDetails(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVenue(int id)
        {
            return Ok();
        }
    }
}
