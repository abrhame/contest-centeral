using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Features.Auth.Requests;
using Api.Helpers;
using Domain.Constant;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthController : ControllerBase 
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUserRequestDto request)
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

    [HttpGet("verifyemail")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyEmail(string token)
    {
        var result = await _mediator.Send(new VerifyEmailCommand(token));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var (result, response) = await _mediator.Send(new LoginUserCommand(request));

        if (result.Success)
        {
            var cookieOptions = new CookieOptions {
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Expires = DateTime.UtcNow.AddDays(7),
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);

            return Ok( new { 
                    Success = result.Success,
                    AccessToken = response.AccessToken,
                    User = response.User,
                    });
        }

        return BadRequest(result);
    }

    [HttpPost("logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (refreshToken == null)
        {
            return BadRequest(new { 
                    Success = false,
                    Message = "Refresh token is required"
                    });
        }

        var result = await _mediator.Send(new LogoutRequest(refreshToken));

        var cookieOptions = new CookieOptions {
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            Expires = DateTime.UtcNow.AddDays(-7),
            SameSite = SameSiteMode.Strict
        };

        Response.Cookies.Append("refreshToken", "", cookieOptions);

        return Ok(result);
    }

    [HttpPost("resetpassword")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(
            ResetPasswordRequestDto request,
            [FromQuery(Name = "token")] string token
            )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(new ResetPasswordCommand(request, token));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("forgotpassword")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(new ForgotPasswordCommand(email));

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (refreshToken == null)
        {
            return BadRequest(new { 
                    Success = false,
                    Message = "Refresh token is required"
                    });
        }

        var (result, response) = await _mediator.Send(new RefreshTokenCommand(refreshToken));

        if (result.Success)
        {
            var cookieOptions = new CookieOptions {
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Expires = DateTime.UtcNow.AddDays(7),
                SameSite = SameSiteMode.Strict
            };

            return Ok( new { 
                    Success = result.Success,
                    AccessToken = response.AccessToken,
                    User = response.User,
                    });
        }

        return BadRequest(result);
    }
}
