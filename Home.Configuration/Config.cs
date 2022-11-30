namespace Home.Configuration
{
    public sealed class Config
    {
        public string? DatabasePath { get; internal set; }
        public string? IoTChiefUrl { get; internal set; }
        public string? MeteoUrl { get; internal set; }
        public int Altitude { get; internal set; }
    }
}
