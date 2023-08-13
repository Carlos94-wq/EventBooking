using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvenBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
       

        [HttpGet]
        public async Task<IActionResult> RetrieveVenues([FromQuery] int id)
        {

            return Ok();
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
