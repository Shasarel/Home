namespace Home.WebApi.Dtos.Energy
{
    public class PowerDto
    {
        public int Production { get; set; }

        public int Import { get; set; }

        public int Export { get; set; }

        public int Use { get; set; }

        public int Consumption { get; set; }

        public int Store { get; set; }
    }
}
