using Application.Interfaces;

namespace Api.Helpers;

public class JWTMiddleware
{
    private readonly RequestDelegate _next;

    public JWTMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, Application.Interfaces.ILogger logger, IUnitOfWork unitOfWork, ITokenService tokenService) 
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            var result = tokenService.ValidateAccessToken(token, out Guid UserId);

            if (result)
            {
                var user = await unitOfWork.UserRepository.GetByIdAsync(UserId);

                if ( user != null ) 
                {
                    context.Items["User"] = user;
                }
            }
        }

        await _next(context);
    }
}
