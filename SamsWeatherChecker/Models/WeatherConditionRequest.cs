using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionRequest
    {
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 100 characters")]
        public string Location { get; set; }

    }
}
