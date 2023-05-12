using SamsWeatherChecker.Models;

namespace SamsWeatherChecker.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherConditionResultViewModel?> GetWeatherByCoordinates(WeatherConditionRequest weatherConditionRequest);

        //Task<WeatherConditionRequest> GetCoordinates(string location);
    }
}
