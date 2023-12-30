using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Features.Auth.Requests;

namespace ContestCentral.Api.Controllers;

[Route("api/auth")]
public class AuthController : ControllerBase {

    private readonly IMediator _mediator;

    public AuthController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequestDto request) {   
        var response = await _mediator.Send(new RegisterUserCommand(request));

        if(response.Success) {
            return CreatedAtAction(nameof(Register), response);
        }

        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequestDto request) {
        return Ok();
    }
    
    [HttpGet("verifyemail/{token}")]
    public async Task<IActionResult> VerifyEmail(string token) {
        var response = await _mediator.Send(new VerifyEmailCommand(token));

        if (response.Item1.Success) {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(string email) {
        var response = await _mediator.Send(new ForgotPasswordRequest(email));

        if (response.Success) {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
