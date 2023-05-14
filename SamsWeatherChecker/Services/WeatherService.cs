using Newtonsoft.Json;
using OpenWeatherAPI;
using SamsWeatherChecker.Interfaces;
using SamsWeatherChecker.Models;

namespace SamsWeatherChecker.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherConditionResultViewModel?> GetWeatherByCoordinates(WeatherConditionRequest weatherConditionRequest) {
            //ADD KEY FROM CONFIG
            var openWeatherAPI = new OpenWeatherAPI.OpenWeatherApiClient("KEY from appsettimgs.json");
            // Use async version wherever possible
            //var query = openWeatherAPI.Query("bedford");
            WeatherConditionResultViewModel? weatherConditionResult = new WeatherConditionResultViewModel();

            try
            {
                var asyncQuery = await openWeatherAPI.QueryAsync(weatherConditionRequest.Location);

                weatherConditionResult = new WeatherConditionResultViewModel()
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
            }
            catch (Exception ex)
            {
                //Log error, return error model
                Console.WriteLine(ex);
                throw ex;
            }
            
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get,
            //    $"https://api.openweathermap.org/data/2.5/weather?lat={weatherConditionRequest.Lat}&lon={weatherConditionRequest.Lon}&appid=caab83dfca13c22ee0ae57ba04aca7e4");
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            //string result = await response.Content.ReadAsStringAsync();

            //try {
            //    weatherConditionResult = JsonConvert.DeserializeObject<WeatherConditionResult>(result ?? "Empty Json response - config value");
            //}
            //catch (JsonSerializationException jsonException)
            //{
            //    Console.WriteLine(jsonException);
            //    return null;
            //}

            return weatherConditionResult;
        }

        //public async Task<WeatherConditionRequest> GetCoordinates(string location)
        //{
        //    //Use Geocoding to get Coordinates from town/city/postcode
        //}
    }
}
