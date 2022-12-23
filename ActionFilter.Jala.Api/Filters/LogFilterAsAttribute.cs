using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Jala.Api.Filters;

public class LogFilterAsAttribute: Attribute, IActionFilter
{
    private readonly string _actionName;

    public LogFilterAsAttribute(string actionName)
    {
        _actionName = actionName;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Before action - {_actionName}, {context.HttpContext.Request?.QueryString.Value}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        // context.HttpContext.Response.WriteAsJsonAsync("json content here");
        Console.WriteLine($"After action");
    }
}