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
    public async Task<IActionResult> Create(CreateLocationRequestDto request)
    {
        var result = await _mediator.Send( new CreateLocationCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(
        Guid Id,
        [FromBody] UpdateLocationRequestDto request
        )
    {
        var result = await _mediator.Send(new UpdateLocationCommand(Id, request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var (result, response) = await _mediator.Send(new GetLocationRequest(Id));

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
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand(Id));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
