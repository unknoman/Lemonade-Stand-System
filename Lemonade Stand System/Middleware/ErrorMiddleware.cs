using Azure;
using Models.ModelsResources;
using System.Net;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

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
                var responseModel = new Responses<string>(){ success = false, message = error?.Message, errors = new List<string>() };

                switch (error)
                {
                    case KeyNotFoundException e:
                       response.StatusCode = (int)HttpStatusCode.NotFound;
                       responseModel.message = "Not Found";
                        responseModel.errors?.Add(e.Message);

                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.message = "Validation errors";
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
