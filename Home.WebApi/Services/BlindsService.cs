using Home.Database.Database;
using Home.Database.Enums.Blinds;
using Home.WebApi.Dtos.Blinds;
using Home.WebApi.Interfaces;

namespace Home.WebApi.Services
{
    public class BlindsService : IBlindsService
    {
        private readonly HomeContext _context;

        public BlindsService(HomeContext context)
        {
            _context = context;
        }

        public void DeleteBlindSchedule(int scheduleId)
        {
            var blindSchedule = _context.BlindSchedule.FirstOrDefault(x => x.Id == scheduleId);

            if (blindSchedule == null)
                return;

            _context.BlindSchedule.Remove(blindSchedule);
            _context.SaveChanges();
        }

        public void DeleteBlindTask(int taskId)
        {
           var blindTask = _context.BlindTask.FirstOrDefault(x => x.Id == taskId);

            if (blindTask == null)
                return;

            _context.BlindTask.Remove(blindTask);
            _context.SaveChanges();
        }

        public BlindsDto GetBlindData(Device blindId)
        {
            var blindTasks = _context.BlindTask
                .Where(x => x.Device == blindId)
                .Select(x => new BlindTaskDto { Id = x.Id, Action = x.Action - 1, Datetime = x.DateTime, PlannedBy = x.User.ToString() })
                .ToList();

            var blindSchedule = _context.BlindSchedule
                .Where(x => x.Device == blindId)
                .Select(x => new BlindScheduleDto { Id = x.Id, Action = x.Action - 1, HourType = x.HourType - 1, PlannedBy = x.User.ToString(), TimeOffset = x.TimeOffset })
                .ToList();

            return new BlindsDto
            {
                BlindTasks = blindTasks,
                BlindSchedules = blindSchedule
            };
        }
    }
}
