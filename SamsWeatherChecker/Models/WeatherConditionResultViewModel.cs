using System.ComponentModel.DataAnnotations;

namespace SamsWeatherChecker.Models
{
    public class WeatherConditionResultViewModel
    {
        public LocationDetails Location { get; set; }

        public WeatherTemperatures WeatherTemperaturesCelsius { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Sunrise { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Sunset { get; set;}

        public String ErrorMessage { get; set; }
    }

    public class WeatherTemperatures
    {
        [Display(Name = "Current Temperature")]
        public double Current { get; set; }

        [Display(Name = "Minimum Temperature")]
        public double Min { get; set; }

        [Display(Name = "Maximum Temperature")]
        public double Max { get; set; }
    }

    public class LocationDetails
    {
        [Display(Name = "City/Town")]
        public string Name { get; set; }

        [Display(Name = "Latitude")]
        public double Lat { get; set; }

        [Display(Name = "Longitude")]
        public double Lon { get; set; }
    }
}
