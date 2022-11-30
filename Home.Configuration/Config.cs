namespace Home.Configuration
{
    public sealed class Config
    {
        public string? DatabasePath { get; set; }
        public string? IoTChiefUrl { get; set; }
        public string? MeteoUrl { get; set; }
        public int Altitude { get; set; }
        public double EnergyReturnFactor { get; set; }
    }
}
