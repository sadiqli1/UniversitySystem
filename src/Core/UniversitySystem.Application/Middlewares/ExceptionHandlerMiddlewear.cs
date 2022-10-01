using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversitySystem.Application.CustomException;

namespace UniversitySystem.Application.Middlewares
{
    public class ExceptionHandlerMiddlewear
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;

        public ExceptionHandlerMiddlewear(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"{ex.Message}");
                //_logger.LogError($"Somthing went wrong: {ex}");
                await HandlerException(context,ex);
                //var a = ex.Message;
                //return ex.Message;
            }

        }
        private Task HandlerException(HttpContext context,Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
          
            switch (ex)
            {
                case NotSucceededException exception:
                    var problemDetails = new
                    {
                        exception.Code,
                        exception.Description,
                    };
                    context.Response.WriteAsJsonAsync(problemDetails);
                    break;
                case BadRequestException exception:
                    var problemDetail = new
                    {
                        exception.Code,
                        exception.Description,
                    };
                    context.Response.WriteAsJsonAsync(problemDetail);
                    break;
                default:
                    var dasda = new
                    {
                        ex.Message,
                    };
                    context.Response.WriteAsJsonAsync(dasda);
                    break;

            }
            return Task.CompletedTask;
            //return context.Response.WriteAsync(new NotSucceededException()
            //{
            //    Code = context.Response.StatusCode,
            //});
        }
    }
}
