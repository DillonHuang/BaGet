using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BaGet
{
    public class NugetAuthorizeFilter : Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter
    {
        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            context.Result = new OkResult();
            
            return base.OnAuthorizationAsync(context);
        }
    }
}
