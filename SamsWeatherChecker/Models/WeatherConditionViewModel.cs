using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionViewModel
    {
        [Display(Name = "City/Town")]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Please enter a valid location")]
        public string LocationName { get; set; }

        [Display(Name = "Latitude")]
        public double? Lat { get; set; }

        [Display(Name = "Longitude")]
        public double? Lon { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Sunrise { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Sunset { get; set;}
        public String? ErrorMessage { get; set; }

        [Display(Name = "Current Temperature")]
        public double? CurrentTemp { get; set; }

        [Display(Name = "Minimum Temperature")]
        public double? MinTemp { get; set; }

        [Display(Name = "Maximum Temperature")]
        public double? MaxTemp { get; set; }
    }
}
