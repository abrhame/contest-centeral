using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Groups.CreateGroup;
using Application.Features.Groups.UpdateGroup;
using Application.Features.Groups.GetGroup;
using Application.Features.Groups.GetAllGroups;
using Application.Features.Groups.DeleteCommand;

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
    public async Task<IActionResult> Create(CreateGroupRequestDto request)
    {
        var result = await _mediator.Send( new CreateGroupCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(
        Guid Id,
        [FromBody] CreateGroupRequestDto request
    )
    {
        var result = await _mediator.Send(new UpdateGroupCommand(Id, request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var (result, response) = await _mediator.Send(new GetGroupRequest(Id));

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var (result, response) = await _mediator.Send(new GetAllGroupsRequest());

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _mediator.Send(new DeleteGroupCommand(Id));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
