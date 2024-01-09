// using AutoMapper;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;

// using ContestCentral.Application.Common.DTOs;
// using ContestCentral.Application.Common.Features.Attendances.Request.Commands;
// using ContestCentral.Application.Common.Features.Attendances.Request.Queries;
// using ContestCentral.Domain.Entities;


// namespace ContestCentral.Api.Controllers;

// [ApiController]
// [Route("api/[Controller]")]
// public class AttendanceController : ControllerBase
// {
//     private readonly IMediator _mediator;
//     private readonly IHttpContextAccessor _httpContextAccessor;
//     private readonly IMapper _mapper;
        
//     public AttendanceController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
//     {
//         _mediator = mediator;
//         _mapper = mapper;
//         _httpContextAccessor = httpContextAccessor;
//     }

//     [HttpPost]
//     public async Task<IActionResult> AddAttendance([FromBody] CreateAttendanceRequestDto request)
//     {
//        try
//        {
//            var command = _mapper.Map<CreateAttendanceCommand>(request);
//            await _mediator.Send(command);

//            return Ok();
//        }
//        catch (Exception ex)
//        {
//            return BadRequest($"Error creating attendance: {ex.Message}");
//        }
//     }


//     [HttpGet("users/{contestId}")]
//     public async Task<IActionResult> GetParticipantsForContest(Guid contestId)
//     {
//         try
//         {
//             var res = await _mediator.Send(new GetUsersByContestIdRequest { ContestId = contestId });
//             return Ok(res);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Error getting users for the contest: {ex.Message}");
//         }
//     }


//     [HttpGet("contests/{userId}")]
//     public async Task<IActionResult> GetContestsForUser(Guid userId)
//     {
//         try
//         {
//             var res = await _mediator.Send(new GetAttendanceByUserIdRequest { UserId = userId });
//             return Ok(res);
//         }
//         catch (Exception ex)
//         {
//             return BadRequest($"Error getting contests for the user: {ex.Message}");
//         }
//     }

// }