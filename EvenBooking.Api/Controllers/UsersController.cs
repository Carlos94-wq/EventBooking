using Microsoft.AspNetCore.Mvc;

namespace EvenBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> RetrieveUserDetails([FromQuery] int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInformacion(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetrieveBookingsByUserId(int id)
        {
            return Ok();
        }
    }
}
