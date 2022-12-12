namespace Home.WebApi.Dtos
{
    public class MeteoDto
    {
        public double Temperature { get; set; }
        public double TemperatureChange { get; set; }
        public double Pressure { get; set; }
        public double PressureChange { get; set; }
        public double Dust { get; set; }
    }
}
