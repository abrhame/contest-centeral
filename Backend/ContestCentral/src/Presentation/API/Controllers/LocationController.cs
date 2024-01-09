using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Locations.Requests;
using Application.Features.Locations.Commands;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase 
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(LocationDto request)
    {
        var result = await _mediator.Send( new CreateLocationCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(LocationDto request)
    {
        var result = await _mediator.Send(new UpdateLocationCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid GroupId)
    {
        var (result, response) = await _mediator.Send(new GetLocationRequest(GroupId));

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var (result, response) = await _mediator.Send(new GetAllLocationsRequest());

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid GroupId)
    {
        var result = await _mediator.Send(new DeleteLocationCommand(GroupId));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
