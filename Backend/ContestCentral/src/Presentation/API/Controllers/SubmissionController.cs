using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Features.Submission.Queries.GetAllSubmissions;
using Application.Features.Submission.Queries.GetSubmissionById;
using Application.Features.Submission.Queries.GetSubmissionByQuestion;
using Application.Features.Submission.Queries.GetSubmissionByUser;
using Application.Features.Submission.Queries.GetSubmissionByContest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Submission.Commands.CreateSubmission;
using Application.Features.Submission.Commands.UpdateSubmission;

namespace API.Controllers
{
    [ApiController]
    [Route("api/submissions")]
    public class SubmissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubmissionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubmissionDTO>>> GetAllSubmissions()
        {
            var query = new GetAllSubmissionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubmissionDTO>> GetSubmissionById(Guid id)
        {
            var query = new GetSubmissionByIdQuery(submissionId: id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SubmissionDTO>>> GetSubmissionsByUserId(Guid userId)
        {
            var query = new GetSubmissionsByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("question/{questionId}")]
        public async Task<ActionResult<IEnumerable<SubmissionDTO>>> GetSubmissionsByQuestionId(string questionId)
        {
            var query = new GetSubmissionsByQuestionIdQuery(questionId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("contest/{contestId}")]
        public async Task<ActionResult<IEnumerable<SubmissionDTO>>> GetSubmissionsByContestId(Guid contestId)
        {
            var query = new GetSubmissionsByContestIdQuery(contestId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SubmissionDTO>> CreateSubmission([FromBody] CreateSubmissionCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSubmissionById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubmissionDTO>> UpdateSubmission(Guid id, [FromBody] UpdateSubmissionCommand command)
        {
            if (id != command.SubmissionId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
