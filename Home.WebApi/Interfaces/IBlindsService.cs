using Home.Database.Enums.Blinds;
using Home.WebApi.Dtos.Blinds;

namespace Home.WebApi.Interfaces
{
    public interface IBlindsService
    {
        BlindsDto GetBlindData(Device blindId);
        void DeleteBlindTask(int taskId);
        void DeleteBlindSchedule(int scheduleId);
    }
}
