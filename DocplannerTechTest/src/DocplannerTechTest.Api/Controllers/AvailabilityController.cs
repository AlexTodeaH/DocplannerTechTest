using DocplannerTechTest.Application.Features.Availability.Commands;
using DocplannerTechTest.Application.Features.Availability.Models;
using DocplannerTechTest.Application.Features.Availability.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocplannerTechTest.Api.Controllers
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
            try
            {
                var query = new GetWeeklyAvailabilityQuery { Date = date };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("TakeSlot")]
        public async Task<IActionResult> TakeSlot([FromBody] TakeSlotRequest slotRequest)
        {
            try
            {
                var command = new TakeSlotCommand { SlotRequest = slotRequest };
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}