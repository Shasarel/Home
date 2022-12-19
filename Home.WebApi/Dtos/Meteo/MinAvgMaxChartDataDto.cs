namespace Home.WebApi.Dtos.Meteo
{
    public class MinAvgMaxChartDataDto
    {
        public List<double?>? Min { get; set; }
        public List<double?>? Max { get; set; }
        public List<double?>? Avg { get; set; }
    }
}
