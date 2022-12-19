using Action = Home.Database.Enums.Blinds.Action;

namespace Home.WebApi.Dtos.Blinds
{
    public class BlindTaskDto
    {
        public int Id { get; set; }
        public Action Action { get; set; }
        public DateTimeOffset Datetime { get; set; }
        public string? PlannedBy { get; set; }
    }
}
