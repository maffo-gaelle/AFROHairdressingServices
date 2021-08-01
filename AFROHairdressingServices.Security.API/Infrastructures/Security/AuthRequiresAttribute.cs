using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Infrastructures.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiresAttribute : TypeFilterAttribute
    {
        public AuthRequiresAttribute() : base(typeof(AuthRequiredFilter)) {}

        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ITokenRepository tokenRepository = (ITokenRepository)context.HttpContext.RequestServices.GetService(typeof(ITokenRepository));

                context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);
                string token = authorizations.SingleOrDefault(authorization => authorization.StartsWith("Bearer "));

                if(token is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                TokenUser user = tokenRepository.ValidateToken(token);
                if(user is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                context.RouteData.Values["userId"] = user.Id;
            }
        }
    }
}
