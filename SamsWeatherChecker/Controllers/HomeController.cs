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
        public IActionResult CurrentWeather(WeatherConditionViewModel weatherConditionViewModel)
        {
            //GET LAT LONG FROM LOCATION STRING (town/city/postcode)
            //WeatherConditionRequest weatherConditionRequest = _weatherService.GetCoordinates(weatherConditionViewModel.Location).Result;
            WeatherConditionRequest weatherConditionRequest = new WeatherConditionRequest() {
                Location = weatherConditionViewModel.Location            
            };

            //GET WEATHER FROM CO-ORDINATES
            try
            {
                var weatherConditionResult = _weatherService.GetWeatherByCoordinates(weatherConditionRequest);
                Console.WriteLine(weatherConditionResult.Result);
                return View(weatherConditionResult.Result);
            }
            catch (Exception ex)
            {
                return View(new WeatherConditionResultViewModel
                {
                    ErrorMessage = _configuration.GetValue("ErrorMessages.WeatherResultError", "Invalid Location, please check and try again")
                });
            }            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}