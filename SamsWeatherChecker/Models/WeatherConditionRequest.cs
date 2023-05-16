using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionRequest
    {
        public string? Location { get; set; }
    }
}
