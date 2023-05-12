using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionViewModel
    {
        [Display(Name = "Town/City")]
        public string Location { get; set; }
    }
}
