using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using ContestCentral.Application.Common.DTOs;
using ContestCentral.Domain.Constants;
using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Features.Auth.Commands;

using ContestCentral.Api.Helpers;

namespace ContestCentral.Api.Controllers;

[Route("api/auth")]
[ApiController]
[Authorize]
public class AuthController : ControllerBase {
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
    }

    [HttpPost("register")]
    [Authorize(Role.Administrator)]
    public async Task<IActionResult> Register(RegisterUserRequestDto requestDto) {   
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        
        var request = new RegisterUserCommand(requestDto);

        var result = await _mediator.Send(request);

        if(result.Success) {
            return CreatedAtAction(nameof(Register), new {
                    success = result.Success, 
                    message = result.Message, 
                    });
        }

        return BadRequest(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserRequestDto requestDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        var request = new LoginUserRequest(requestDto);

        var (result, response) = await _mediator.Send(request);

        if (result.Success) {

            var cookieOptions = new CookieOptions {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", response.refreshToken, cookieOptions);
            return Ok(new { 
                    success = result.Success, 
                    message = result.Message, 
                    accessToken = response.accessToken, 
                    user = response.user 
                    });
        }

        return BadRequest(result);
    }
    
    [HttpGet("verifyemail")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyEmail([FromQuery] string token) {
        var result = await _mediator.Send(new VerifyEmailCommand(token)); 

        if (result.Success) {
            return Ok(new { 
                    success = result.Success, 
                    message = result.Message, 
                    });
        }

        return BadRequest(result);
    }

    [HttpPost("forgotpassword")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(string email) {
        var result = await _mediator.Send(new ForgotPasswordRequest(email));

        if (result.Success) {
            return Ok(
                    new { 
                        success = result.Success, 
                        message = result.Message, 
                        }
                    );
        }

        return BadRequest(result);
    }

    [HttpPost("resetpassword/{token}")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(
            string token,
            [FromBody] ResetPasswordRequestDto requestDto
            ) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        if (requestDto.newPassword != requestDto.confirmPassword) {
            return BadRequest(new { errors = new string[] {"Passwords do not match"} });
        }

        var result = await _mediator.Send(new ResetPasswordCommand(token, requestDto));

        if (result.Success) {
            return Ok(
                    new { 
                        success = result.Success, 
                        message = result.Message, 
                        }
                    );
        }

        return BadRequest(result);
    }

    [HttpPost("refreshtoken")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(string token) {

        var (result, response) = await _mediator.Send(new RefreshTokenCommand(token));

        if (result.Success) {
            return Ok(
                    new { 
                        success = result.Success, 
                        message = result.Message, 
                        accessToken = response.accessToken, 
                        user = response.user 
                        }
                    );
        }

        return BadRequest(result);
    }

    [HttpPost("revoketoken")]
    public Task<IActionResult> RevokeToken(string token) {
        throw new NotImplementedException();
    }
}
