using OpenWeatherAPI;
using SamsWeatherChecker.Controllers;
using SamsWeatherChecker.Interfaces;
using SamsWeatherChecker.Models;

namespace SamsWeatherChecker.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _configuration;

        public WeatherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<WeatherConditionModel?> GetWeatherByCoordinates(WeatherConditionRequest weatherConditionRequest) {

            var openWeatherAPI = new OpenWeatherApiClient(_configuration.GetValue<string>("WeatherServiceAPIKey"));

            try
            {
                var asyncQuery = await openWeatherAPI.QueryAsync(weatherConditionRequest.Location);

                WeatherConditionModel weatherConditionResult = new WeatherConditionModel()
                {
                    Location = new LocationDetails()
                    {
                        Name = weatherConditionRequest.Location,
                        Lat = asyncQuery.Coordinates.Latitude,
                        Lon = asyncQuery.Coordinates.Longitude
                    },
                    WeatherTemperaturesCelsius = new WeatherTemperatures()
                    {
                        Current = asyncQuery.Main.Temperature.CelsiusCurrent,
                        Min = asyncQuery.Main.Temperature.CelsiusMinimum,
                        Max = asyncQuery.Main.Temperature.CelsiusMaximum
                    },
                    Sunrise = asyncQuery.Sys.Sunrise,
                    Sunset = asyncQuery.Sys.Sunset
                };

                return weatherConditionResult;
            }
            catch (Exception ex)
            {
                //Log error, return error model
                Console.WriteLine(ex);
                throw;
            }       
        }
    }
}
