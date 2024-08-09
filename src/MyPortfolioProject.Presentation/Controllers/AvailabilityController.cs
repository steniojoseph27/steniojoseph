using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Application.UseCases;

namespace MyPortfolioProject.Presentation.Controllers
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

        [HttpPost]
        public async Task<ActionResult<AvailabilityDto>> CreateAvailability([FromBody] AvailabilityDto availabilityDto)
        {
            var result = await _mediator.Send(new CreateAvailabilityUseCase { Availability = availabilityDto });
            return CreatedAtAction(nameof(GetAvailabilityById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AvailabilityDto>> GetAvailabilityById(Guid id)
        {
            var availability = await _mediator.Send(new GetAvailabilityByIdUseCase { Id = id });
            if (availability == null)
            {
                return NotFound();
            }
            return Ok(availability);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<AvailabilityDto>>> GetAvailabilityForUser(Guid userId)
        {
            var availabilities = await _mediator.Send(new GetAvailabilityForUserUseCase { UserId = userId });
            return Ok(availabilities);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(Guid id, [FromBody] AvailabilityDto availabilityDto)
        {
            if (id != availabilityDto.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(new UpdateAvailabilityUseCase { Availability = availabilityDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailability(Guid id)
        {
            await _mediator.Send(new DeleteAvailabilityUseCase { Id = id });
            return NoContent();
        }
    }
}
