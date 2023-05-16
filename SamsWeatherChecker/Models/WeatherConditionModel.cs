using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionModel
    {
        public LocationDetails Location { get; set; } = new LocationDetails();

        public WeatherTemperatures WeatherTemperaturesCelsius = new WeatherTemperatures();
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set;}
    }

    public class WeatherTemperatures
    {
        public double Current { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public class LocationDetails
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
