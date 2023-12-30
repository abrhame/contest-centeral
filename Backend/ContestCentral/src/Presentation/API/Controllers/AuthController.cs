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
    public async Task<IActionResult> Register(RegisterUserRequestDto requestDto) {   
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        
        var request = new RegisterUserCommand(
                requestDto.UserName, 
                requestDto.FirstName, 
                requestDto.LastName, 
                requestDto.Email, 
                requestDto.Password, 
                requestDto.Role,
                requestDto.PhoneNumber
                );

        var response = await _mediator.Send(request);

        if(response.Success) {
            return CreatedAtAction(nameof(Register), response);
        }

        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequestDto requestDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var request = new LoginUserRequest(requestDto.Email, requestDto.Password);

        var (result, response) = await _mediator.Send(request);


        if (result.Success) {
            return Ok(response);
        }

        return BadRequest(result);
    }
    
    [HttpGet("verifyemail")]
    public async Task<IActionResult> VerifyEmail([FromQuery] string token, Guid userId) {
        var (result, response) = await _mediator.Send(new VerifyEmailCommand(token, userId)); 

        if (result.Success) {
            return Ok(response);
        }

        return BadRequest(result);
    }

    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword(string email) {
        var response = await _mediator.Send(new ForgotPasswordRequest(email));

        if (response.Success) {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword([FromQuery]string password, Guid userId) {
        var response = await _mediator.Send(new ResetPasswordCommand(password, userId));

        if (response.Success) {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("refreshtoken")]
    public Task<IActionResult> RefreshToken(string token, string refreshToken) {
        // var response = await _mediator.Send(new RefreshTokenCommand(token, refreshToken));
        //
        // if (response.Success) {
        //     return Ok(response);
        // }
        //
        // return BadRequest(response);
        throw new NotImplementedException();
    }
}
