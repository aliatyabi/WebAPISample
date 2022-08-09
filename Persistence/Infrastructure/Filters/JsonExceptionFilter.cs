using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Persistence.Infrastructure.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;

        public JsonExceptionFilter(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (_environment.IsDevelopment())
            {
                if(context.Exception.InnerException != null)
                {
                    error.Message = context.Exception.InnerException.Message;
                }
                else
                {
                    error.Message = context.Exception.Message;
                }

                error.Details = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "An internal server error occured!";

                error.Details = context.Exception.Message;
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
