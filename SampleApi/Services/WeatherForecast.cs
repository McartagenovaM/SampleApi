namespace SampleApi.Services
{
    public class WeatherForecast
    {
        private readonly HttpClient _httpClient;

        public WeatherForecast(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"https://wttr.in/{city}?format=3";
            return await _httpClient.GetStringAsync(url);
        }
    }
}
