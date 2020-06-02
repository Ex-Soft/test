namespace WebApp
{
    public class DbServiceSettings : IDbServiceSettings
    {
        public string BaseAddress { get; set; }
        public string Api { get; set; }
    }

    public interface IDbServiceSettings
    {
        public string BaseAddress { get; set; }
        public string Api { get; set; }
    }
}
