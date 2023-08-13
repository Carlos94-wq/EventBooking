using EvenBooking.Api.Payloads.Requests;
using EvenBooking.Api.Payloads.Responses;
using EventBooking.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EvenBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<LogUserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LogUserRequest request)
        {
            var result = await _mediator.Send(new LoginUser.Command(request.UserName, request.Password));
            var response = new LogUserResponse(result.User, result.token);

            var apiResponse = new ApiResponse<LogUserResponse>(response);

            return Ok(apiResponse);
        }
    }
}
