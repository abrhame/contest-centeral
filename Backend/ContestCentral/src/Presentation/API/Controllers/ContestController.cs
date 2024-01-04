using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Contests.Commands;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContestsController : ControllerBase 
{
    private readonly IMediator _mediator;

    public ContestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ContestDto request)
    {
        var result = await _mediator.Send( new CreateContestCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return Ok(result);
    }
}