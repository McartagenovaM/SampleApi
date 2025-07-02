namespace SampleApi.Services
{
    public class DummyUserService
    {
        public IEnumerable<string> GetUsers() => new[] { "Alice", "Bob", "Charlie" };

    }
}
