namespace Home.WebApi.Dtos.Energy
{
    public class EnergyDto
    {
        public double Production { get; set; } = 0;

        public double Import { get; set; } = 0;

        public double Export { get; set; } = 0;

        public double Use { get; set; } = 0;

        public double Consumption { get; set; } = 0;

        public double Store { get; set; } = 0;

        public static EnergyDto operator +(EnergyDto left, EnergyDto right) => new()
        {
            Production = Math.Round(left.Production + right.Production, 2),
            Import = Math.Round(left.Import + right.Import, 2),
            Export = Math.Round(left.Export + right.Export, 2),
            Use = Math.Round(left.Use + right.Use, 2),
            Consumption = Math.Round(left.Consumption + right.Consumption, 2),
            Store = Math.Round(left.Store + right.Store, 2),
        };
    }
}
