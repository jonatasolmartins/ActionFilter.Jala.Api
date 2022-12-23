using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Jala.Api.Filters;

public class LogAsyncFilter: Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("Before async");
        await next.Invoke();
        // context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        // context.HttpContext.Response.WriteAsJsonAsync("json content here");
        Console.WriteLine("After async");
    }
}