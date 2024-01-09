using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Locations.Requests;
using Application.Features.Locations.Commands;
using Api.Helpers;
using Domain.Constant;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LocationController : ControllerBase 
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> Create(CreateLocationRequestDto request)
    {
        var result = await _mediator.Send( new CreateLocationCommand(request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("update/{id:guid}")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateLocationRequestDto request
        )
    {
        var result = await _mediator.Send(new UpdateLocationCommand(id, request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("get/{id:guid}")]
    [Authorize(Role.Administrator, Role.Student, Role.ContestCreator, Role.HeadOfEducation)]
    public async Task<IActionResult> Get(Guid id)
    {
        var (result, response) = await _mediator.Send(new GetLocationRequest(id));

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpGet("get")]
    [Authorize(Role.Administrator, Role.Student, Role.ContestCreator, Role.HeadOfEducation)]
    public async Task<IActionResult> Get()
    {
        var (result, response) = await _mediator.Send(new GetAllLocationsRequest());

        if (result.Success)
        {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpDelete("delete/{id:guid}")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand(id));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
