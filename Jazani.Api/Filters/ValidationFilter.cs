using Jazani.Api.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jazani.Api.Filters;
public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid) {
            var errorModelState = context.ModelState.Where(m => m.Value?.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage)).ToList();

            ErrorResponse errorResponse = new() { 
                Message = "Ingrese todos los campos requeridos",
                Errors = new List<ErrorValidationModel>()
            };

            foreach (var item in errorModelState)
            {
                foreach (var message in item.Value) {
                    errorResponse.Errors.Add(new() { 
                        FieldName = item.Key,
                        Message = message
                    });
                }
            }

            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }

        await next();
    }
}
