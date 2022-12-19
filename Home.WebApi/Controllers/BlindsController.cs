using Home.Database.Enums.Blinds;
using Home.WebApi.Dtos.Blinds;
using Home.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BlindsController : ControllerBase
    {
        private readonly IBlindsService _blindsService;

        public BlindsController(IBlindsService blindsService)
        {
            _blindsService = blindsService;
        }

        [HttpGet]
        public BlindsDto BlindData(Device blindId)
        {
            return _blindsService.GetBlindData(blindId);
        }

        [HttpDelete]
        public ActionResult DeleteBlindSchedule(int id)
        {
            _blindsService.DeleteBlindSchedule(id);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBlindTask(int id)
        {
            _blindsService.DeleteBlindTask(id);

            return Ok();
        }
    }
}
