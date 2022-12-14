namespace Home.WebApi.Dtos.Meteo
{
    public class MeteoChartDataDto
    {
        public MinAvgMaxChartDataDto? Temperature { get; set; }
        public MinAvgMaxChartDataDto? Pressure { get; set; }
        public MinAvgMaxChartDataDto? Dust { get; set; }
        public List<string>? Labels { get; set; }
    }
}
