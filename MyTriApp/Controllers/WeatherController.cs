using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTriApp.Weather_API;
using MyTriApp.Weather_API.DTOs;

namespace MyTriApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IWeatherAPI _weatherAPI;

        public WeatherController(IWeatherAPI weatherAPI)
        {
            _weatherAPI = weatherAPI;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherDTO>> GetWeather(float lattitude, float longitude, DateTime dateTime)
        {
            var weather = await _weatherAPI.GetWeather(lattitude, longitude, dateTime);
            if(weather == null)
            {
                return Ok("No weather data found");
            }
            else
            {
                return Ok(weather);
            };
        }
    }
}
