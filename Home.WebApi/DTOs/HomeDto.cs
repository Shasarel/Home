using Home.WebApi.Dtos.Energy;

namespace Home.WebApi.Dtos
{
    public class HomeDto
    {
        public EnergyDto? EnergyToday { get; set; }
        public EnergyDto? EnergyYesterday { get; set; }

        public EnergyDto? EnergyThisYear { get; set; }
        public EnergyDto? EnergyLastYear { get; set; }

        public EnergyDto? EnergyAll { get; set; }

        public double MaxEnergyStore { get; set; }    
    }
}
