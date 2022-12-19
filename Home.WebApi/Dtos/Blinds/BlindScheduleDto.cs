using Home.Database.Enums.Blinds;
using Action = Home.Database.Enums.Blinds.Action;

namespace Home.WebApi.Dtos.Blinds
{
    public class BlindScheduleDto
    {
        public int Id { get; set; }
        public Action Action { get; set; }
        public HourType HourType { get; set; }
        public int TimeOffset { get; set; }
        public string? PlannedBy { get; set; }
    }
}
