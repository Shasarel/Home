namespace Home.WebApi.DTOs
{
    public class EnergyDto
    {
        public double Production { get; set; }

        public double Import { get; set; }

        public double Export { get; set; }

        public double Use => 1;

        public double Consumption => 1;

        public double Store => 1;
    }
}
