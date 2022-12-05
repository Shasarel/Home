namespace Home.WebApi.Dtos
{
    public class ElectricityChartDataDto
    {
        public List<double?>? Production { get; set; }
        public List<double?>? Consumption { get; set; }
        public List<double?>? Use { get; set; }
        public List<double?>? Import { get; set; }
        public List<double?>? Export { get; set; }
        public List<double?>? Store { get; set; }
        public List<string>? Labels { get; set; }
        public string? ChartType { get; set; }
    }
}
