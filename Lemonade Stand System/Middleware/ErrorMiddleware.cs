using Azure;
using Models.ModelsResources;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Lemonade_Stand_System.Middleware

{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            try
            {
                await _next(context);
            } catch (Exception error)
            {
                var responseModel = new Responses<string>(){ success = false, message = error.Message};

                switch (error)
                {
                    case KeyNotFoundException e:
                       response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.message = e.Message;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.message = e.Message;
                        break;
                    default:

                        break;
                }
                
                        var result = JsonSerializer.Serialize(responseModel);
                        await response.WriteAsync(result);
            }
        }


    }
}
