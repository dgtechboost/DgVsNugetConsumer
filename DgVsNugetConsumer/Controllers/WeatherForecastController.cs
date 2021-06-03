using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgLoggers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DgVsNugetConsumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITextLogger _textLogger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ITextLogger textLogger
            )
        {
            _logger = logger;
            _textLogger = textLogger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //here we initiate the package logger
            var pckgLogger = new TextLogger();
            pckgLogger.Log("test logger");

            _textLogger.Log("test logger update");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
