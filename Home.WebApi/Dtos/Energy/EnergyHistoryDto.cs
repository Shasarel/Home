namespace Home.WebApi.Dtos.Energy
{
    public class EnergyHistoryDto
    {
        public EnergyDto? Energy { get; set; }
        public EnergyDto? EnergyPrevious { get; set; }
        public ElectricityChartDataDto? ChartData { get; set; }
    }
}
