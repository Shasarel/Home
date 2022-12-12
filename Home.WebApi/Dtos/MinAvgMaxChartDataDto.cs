namespace Home.WebApi.Dtos
{
    public class MinAvgMaxChartDataDto
    {
        public List<double?>? Min { get; set; }
        public List<double?>? Max { get; set; }
        public List<double?>? Avg { get; set; }
    }
}
