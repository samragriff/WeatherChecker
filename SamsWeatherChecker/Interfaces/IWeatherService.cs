using SamsWeatherChecker.Models;

namespace SamsWeatherChecker.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherConditionModel?> GetWeatherByCoordinates(WeatherConditionRequest weatherConditionRequest);
    }
}
