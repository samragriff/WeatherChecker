using Microsoft.AspNetCore.Mvc;
using SamsWeatherChecker.Interfaces;
using SamsWeatherChecker.Models;
using System.Diagnostics;

namespace SamsWeatherChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService, IConfiguration configuration)
        {
            _logger = logger;
            _weatherService = weatherService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            WeatherConditionViewModel weatherConditionViewModel = new WeatherConditionViewModel();

            return View(weatherConditionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CurrentWeather(WeatherConditionViewModel weatherConditionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(new WeatherConditionViewModel
                {
                    ErrorMessage = ModelState?.Values.FirstOrDefault()?.Errors?.FirstOrDefault()?.ErrorMessage
                });
            }

            WeatherConditionRequest weatherConditionRequest = new WeatherConditionRequest();
            weatherConditionRequest.Location = weatherConditionViewModel.LocationName;            

            try
            {
                //USE MAPPER?
                var weatherConditionResult = await _weatherService.GetWeatherByCoordinates(weatherConditionRequest);
                weatherConditionViewModel.LocationName = weatherConditionResult?.Location.Name;
                weatherConditionViewModel.Lat = weatherConditionResult?.Location.Lat;
                weatherConditionViewModel.Lon = weatherConditionResult?.Location.Lon;
                weatherConditionViewModel.Sunrise = weatherConditionResult.Sunrise;
                weatherConditionViewModel.Sunset = weatherConditionResult.Sunset;
                weatherConditionViewModel.CurrentTemp = weatherConditionResult.WeatherTemperaturesCelsius.Current;
                weatherConditionViewModel.MinTemp = weatherConditionResult.WeatherTemperaturesCelsius.Min;
                weatherConditionViewModel.MaxTemp = weatherConditionResult.WeatherTemperaturesCelsius.Max;
                return View(weatherConditionViewModel);
            }
            catch (Exception ex)
            {
                return View(new WeatherConditionViewModel
                {
                    ErrorMessage = _configuration.GetValue("ErrorMessages:WeatherResultError", "Invalid Location, please check and try again")
                });
            }            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}