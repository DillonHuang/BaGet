using BaGet.Core.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaGet
{
    public interface IMiddlewareAuthenticationService
    {
        Task<bool> AuthenticateAsync(HttpContext httpContext);
    }

    public class MiddlewareAuthenticationService : IMiddlewareAuthenticationService
    {
        private readonly string _accessToken;

        public MiddlewareAuthenticationService(IOptionsSnapshot<BaGetOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            _accessToken = string.IsNullOrEmpty(options.Value.AccessToken) ? null : options.Value.AccessToken;
        }

        public Task<bool> AuthenticateAsync(HttpContext httpContext)
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                return Task.FromResult(true);
            }

            if (!httpContext.Request.Query.ContainsKey("token"))
            {
                return Task.FromResult(false);
            }
            var parameterValue = httpContext.Request.Query["token"];
            if (parameterValue.ToString().Trim()!= this._accessToken.Trim())
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);

        }
    }
}
