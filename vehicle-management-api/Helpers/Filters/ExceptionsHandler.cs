using Microsoft.AspNetCore.Diagnostics;
using vehicle_management_api.Helpers.Models;

namespace vehicle_management_api.Helpers.Filters
{
    public class ExceptionsHandler
    {
        public static void Configure(WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    string thrownMessage = context.Features?.Get<IExceptionHandlerFeature>()?.Error.Message ?? "";
                    string customErrorMessage = thrownMessage.StartsWith("ERRORS") ? thrownMessage : "ERRORS.GENERAL";
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    //CreateLog(context.Request, String.IsNullOrEmpty(thrownMessage) ? customErrorMessage : thrownMessage);
                    await context.Response.WriteAsJsonAsync(ResponseResult<string>.Error(customErrorMessage));
                });
            });
        }
    }
}
