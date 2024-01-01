using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Groups.CreateGroup;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController : ControllerBase 
{
    private readonly IMediator _mediator;

    public GroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateGroupDto request)
    {
        var result = await _mediator.Send( new CreateGroupCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return Ok(result);
    }
}
