using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementSystem.API.AccessControl
{
    public class HasRightHandler : AuthorizationHandler<HasUserRightRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasUserRightRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "user-right" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;
            
            var scopes = context.User.FindFirst(c => c.Type == "user-right" && c.Issuer == requirement.Issuer).Value.Split(' ');

            if (scopes.Any(s => s == requirement.Right))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
