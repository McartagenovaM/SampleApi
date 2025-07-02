namespace SampleApi.Services
{
    public class DummyLogService
    {
        public void Log(string message) => Console.WriteLine($"[LOG] {message}");

    }
}
