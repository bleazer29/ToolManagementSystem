using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementSystem.API.AccessControl
{
    public class HasUserRightRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Right { get; }

        public HasUserRightRequirement(string right, string issuer)
        {
            Right = right ?? throw new ArgumentNullException(nameof(right));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}
