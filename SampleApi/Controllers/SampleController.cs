using Microsoft.AspNetCore.Mvc;
using SampleApi.Services;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly WeatherForecast _weatherService;
        private readonly DummyMathService _mathService;
        private readonly DummyUserService _userService;
        private readonly DummyLogService _logService;

        public SampleController(
            WeatherForecast weatherService,
            DummyMathService mathService,
            DummyUserService userService,
            DummyLogService logService)
        {
            _weatherService = weatherService;
            _mathService = mathService;
            _userService = userService;
            _logService = logService;
        }

        [HttpGet("weather/{city}")]
        public async Task<IActionResult> GetWeather(string city) =>
            Ok(await _weatherService.GetWeatherAsync(city));

        [HttpGet("sum")]
        public IActionResult Sum(int a, int b) =>
            Ok(_mathService.Sum(a, b));

        [HttpGet("users")]
        public IActionResult GetUsers() =>
            Ok(_userService.GetUsers());

        [HttpPost("log")]
        public IActionResult Log([FromBody] string message)
        {
            _logService.Log(message);
            return Ok("Message logged.");
        }
    }

}
