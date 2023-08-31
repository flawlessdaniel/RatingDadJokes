using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RatingDadJokesAPI.Exceptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public CustomExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
            {
                return;
            }

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString(),
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
