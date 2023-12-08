using MyTriApp.Types;
using MyTriApp.Weather_API.DTOs;

namespace MyTriApp.Weather_API
{
    public interface IWeatherAPI
    {
        Task<Result<WeatherDTO>> GetWeather(float lattitude, float longitude, DateTime dateTime);
    }
}