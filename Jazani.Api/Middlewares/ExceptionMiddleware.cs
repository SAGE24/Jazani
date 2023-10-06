using Jazani.Api.Exeptions;
using Jazani.Application.Cores.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Jazani.Api.Middlewares;
public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try {
            await next(context);
        }
        catch (Exception ex) {
            var errorResult = new ErrorModel();
            HttpStatusCode statusCode;

            switch (ex) {
                case NotFoundCoreException:
                    statusCode = HttpStatusCode.NotFound;
                    errorResult.Message = ex.Message;
                    _logger.LogWarning("NotFoundCoreException: {ex}", ex);
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    errorResult.Message = "Se ha producido un error inesperado";
                    _logger.LogError("Exception: {ex}", ex);
                    break;
            }

            var response = context.Response;
            
            if (!response.HasStarted) { 
                response.ContentType = "application/json";
                response.StatusCode = (int)statusCode;

                await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
            }
        }
    }
}
