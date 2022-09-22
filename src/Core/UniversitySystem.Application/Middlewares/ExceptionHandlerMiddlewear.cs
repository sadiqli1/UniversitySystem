using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UniversitySystem.Application.CustomException;

namespace UniversitySystem.Application.Middlewares
{
    public class ExceptionHandlerMiddlewear
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddlewear(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                //_logger.LogError($"Somthing went wrong: {ex}");
                //await HandlerException(context);
                //var a = ex.Message;
                //return ex.Message;
            }
        }
        //private Task HandlerException(HttpContext context)
        //{
        //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //    context.Response.ContentType = "application/json";
        //    return context.Response.WriteAsync(new NotSucceededException()
        //    {
        //        Code = context.Response.StatusCode,
        //    });
        //}
    }
}
