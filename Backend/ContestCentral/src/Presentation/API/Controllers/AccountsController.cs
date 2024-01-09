using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Features.Account.Requests;
using Api.Helpers;
using Domain.Constant;
using Domain.Entity;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ControllerBase 
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> Register(CreateUserRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(new RegisterUserCommand(request));

        if (result.Success)
        {
            return CreatedAtAction(nameof(Register), new
                    {
                    success = result.Success,
                    message = result.Message
                    });
        }

        return BadRequest(result);
    }

    [HttpGet("get")]
    [Authorize(Role.Administrator, Role.HeadOfEducation, Role.ContestCreator)]
    public async Task<IActionResult> GetAccounts()
    {
        var (result, response) = await _mediator.Send(new GetAllAccountsRequest());

        if (result.Success)
        {
            return Ok(
                new {
                    success = result.Success,
                    response
                });
        }

        return BadRequest(result);
    }

    [HttpGet("get/{id:guid}")]
    [Authorize(Role.Administrator, Role.HeadOfEducation, Role.ContestCreator, Role.Student)]
    public async Task<IActionResult> GetAccount(Guid id)
    {
        Console.WriteLine("THE ID IS", id);

        var user = (User?)HttpContext.Items["User"];


        if (user?.Role == Role.Student && user.Id != id)
        {
            return Unauthorized(new { 
                    Success = false,
                    Message = "Unauthorized"
                    });
        }

        var (result, response) = await _mediator.Send(new GetAccountRequest(id));

        if (result.Success)
        {
            return Ok(
                new {
                    success = result.Success,
                    response
                });
        }

        return BadRequest(result);
    }

    [HttpPut("update")]
    [Authorize(Role.Administrator, Role.HeadOfEducation, Role.ContestCreator, Role.Student)]
    public async Task<IActionResult> UpdateAccount(
            [FromBody] UpdateUserRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = (User?)HttpContext.Items["User"];

        if ( user == null)
        {
            return Unauthorized(new { 
                    Success = false,
                    Message = "Unauthorized"
                    });
        }

        var result = await _mediator.Send(new UpdateAccountCommand(user.Id, request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }


    [HttpPut("update/role/{id:guid}")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> UpdateAccountRole(
            Guid id, 
            [FromBody] Role request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(new UpdateUserRoleCommand(id, request));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }


    [HttpDelete("delete/{id:guid}")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> DeleteAccount ( Guid id)
    {
        var result = await _mediator.Send(new DeleteAccountCommand(id));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
