using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ContestCentral.Domain.Constants;
using ContestCentral.Domain.Common.Entity;

namespace ContestCentral.Api.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter {
    private readonly IList<Role> _roles;

    public AuthorizeAttribute(params Role[] roles) {
        _roles = roles ?? new Role[] { };
    }

    public void OnAuthorization(AuthorizationFilterContext context) {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<Attribute>().Any();
        if (allowAnonymous)
            return;

        var user = (User?)context.HttpContext.Items["User"];

        Console.WriteLine($"User Role: {user?.Role}");
        Console.WriteLine($"Roles: {_roles}");

        if (user == null && _roles.Any() || _roles.Any() && user != null && !_roles.Contains(user.Role)) {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }
    }
}


