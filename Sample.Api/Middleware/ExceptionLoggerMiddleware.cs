using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.Domain.Base;

namespace Sample.Api.Middleware
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionLoggerMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("ExceptionLoggerMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException domainException)
            {
                _logger.LogError(domainException, nameof(ExceptionHandlerMiddleware));
                await HandleDomainException(httpContext, domainException);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ExceptionHandlerMiddleware));
            }
        }

        private async Task HandleDomainException(HttpContext context, DomainException domainException)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            //Code can(should) be correlated with specific domain exception
            var errorModel = new { Code = domainException.Code, Message = domainException.Message };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggerMiddleware>();
        }
    }
}
