using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockApi.UI.Models;

namespace StockApi.UI.Filters
{
    public class ApiModelValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                KeyValuePair<string,IEnumerable<string>>[] errorsInModelState=context.ModelState.
                    Where(x=>x.Value.Errors.Count>0)
                    .ToDictionary(x => x.Key, 
                    x => x.Value.Errors.Select(x=>x.ErrorMessage))
                    .ToArray();
                var errorResponse = new ErrorResponse();

                foreach(var error in errorsInModelState)
                {
                    foreach(var subError in error.Value)
                    {
                        errorResponse.Errors.Add(new ErrorModel()
                        {
                            FieldName=error.Key,
                            Message=subError
                        });
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
           await next();
        }
    }
}
