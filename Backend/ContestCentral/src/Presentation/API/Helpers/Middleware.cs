using ContestCentral.Infrastructure.Persistence;
using ContestCentral.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ContestCentral.Api.Helpers;

public class JwtMiddleware {
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task Invoke(HttpContext context,  ContestCentralDbContext dbContext, ITokenService tokenService ) {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if ( token != null ) {
            var userId = tokenService.ValidateToken(token, out Guid tokenId);

            if ( userId != null ) {
                context.Items["User"] = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            }
        }

        await _next(context);
    }
}
