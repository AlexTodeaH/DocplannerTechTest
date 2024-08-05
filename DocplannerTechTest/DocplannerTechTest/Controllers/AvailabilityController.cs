using Microsoft.AspNetCore.Mvc;

namespace DocplannerTechTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvailabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetWeeklyAvailability/{date}")]
        public async Task<IActionResult> GetWeeklyAvailability(string date)
        {
            var query = new GetWeeklyAvailabilityQuery { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("TakeSlot")]
        public async Task<IActionResult> TakeSlot([FromBody] SlotRequestModel slotRequest)
        {
            var command = new TakeSlotCommand { SlotRequest = slotRequest };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
