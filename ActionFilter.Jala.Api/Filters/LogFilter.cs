using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Jala.Api.Filters;

public class LogFilter : IActionFilter
{
    private readonly ILogger<LogFilter> _logger;

    public LogFilter(ILogger<LogFilter> logger)
    {
        _logger = logger;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.Log(LogLevel.Debug, "Before");
        Console.WriteLine("Before - OnActionExecuting");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.Log(LogLevel.Debug, "After");
        Console.WriteLine("After - OnActionExecuted");
    }
}