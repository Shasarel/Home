namespace Home.WebApi.DTOs
{
    public class EnergyDto
    {
        public double Production { get; set; }

        public double Import { get; set; }

        public double Export { get; set; }

        public double Use { get; set; }

        public double Consumption { get; set; }

        public double Store { get; set; }
    }
}
