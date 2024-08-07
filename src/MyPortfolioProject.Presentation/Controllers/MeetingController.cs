using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Application.UseCases;

namespace MyPortfolioProject.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("schedule")]
        public async Task<ActionResult<MeetingDto>> ScheduleMeeting([FromBody] MeetingDto meetingDto)
        {
            var result = await _mediator.Send(new ScheduleMeetingUseCase { Meeting = meetingDto });
            return CreatedAtAction(nameof(GetMeetingById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeetingById(Guid id)
        {
            var meeting = await _mediator.Send(new GetMeetingByIdUseCase { Id = id });
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetMeetingsForUser(Guid userId)
        {
            var meetings = await _mediator.Send(new GetMeetingsForUserUseCase { UserId = userId });
            return Ok(meetings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(Guid id, [FromBody] MeetingDto meetingDto)
        {
            if (id != meetingDto.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(new UpdateMeetingUseCase { Meeting = meetingDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(Guid id)
        {
            await _mediator.Send(new DeleteMeetingUseCase { Id = id });
            return NoContent();
        }
    }
}
