using ActionFilter.Jala.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Jala.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [LogFilterAs("GetFilter")]
    [LogAsyncFilter]
    public IEnumerable<WeatherForecast> Get(string queryString)
    {
        Console.WriteLine("GetWeatherForecast Action");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet]
    public IActionResult GetFilter()
    {
        return Ok();
    }
    
}