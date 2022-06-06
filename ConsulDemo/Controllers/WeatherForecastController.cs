using ConsulDemo.Helpers;
using ConsulDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsulDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var consulDemoKey = await ConsulKeyValueProvider.GetValueAsync<ConsulDemoKey>("ConsulDemoKey");

            if (consulDemoKey != null && consulDemoKey.IsEnabled)
                return Ok(consulDemoKey);

            return Ok("ConsulDemoKey is null");
        }
    }
}