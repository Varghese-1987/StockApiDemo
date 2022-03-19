using Microsoft.AspNetCore.Diagnostics;

namespace StockApi.UI.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder application,Serilog.ILogger logger)
        {
            application.UseExceptionHandler((errorConfiguration) =>
            {
                errorConfiguration.Run(async errorContext =>
                {
                    var exceptionObject = errorContext.Features.Get<IExceptionHandlerFeature>();
                    logger.Error($"Exception Error: {exceptionObject?.Error.Message} \n Stack Trace: {exceptionObject?.Error.StackTrace}");
                    var problemDetails = new HttpValidationProblemDetails()
                    {
                        Title = "An Internal Server Error Occured",
                        Status = StatusCodes.Status500InternalServerError,
                    };
                    await errorContext.Response.WriteAsJsonAsync(problemDetails,
                        problemDetails.GetType(),
                        null,
                        contentType: "application/json");
                });

            });
        }
    }
}
