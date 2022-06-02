using Microsoft.AspNetCore.Mvc.Filters;

namespace Dep.App.Security.Api.Filters
{
    public class SecurityFilterErrors : IExceptionFilter
    {
        private readonly ILogger<SecurityFilterErrors> _logger;

        public SecurityFilterErrors(ILogger<SecurityFilterErrors> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"{context.HttpContext.Request.Path} provocó el error {context.Exception.Message} {context.Exception.StackTrace}");
        }
    }
}
