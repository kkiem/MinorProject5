using Microsoft.AspNetCore.Mvc;
using MinorProject5.Api.Business;
using MinorProject5.Api.Models;

namespace MinorProject5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private BusinessLayer biz = new BusinessLayer();

        [HttpGet]
        public List<PlayerServiceModel> GetAll()
        {
            return biz.GetPlayers();
        }

        [HttpGet("{id}")]
        public ActionResult<PlayerServiceModel> GetById(int id)
        {
            PlayerServiceModel? player = biz.GetPlayer(id);
            if (player == null) return NotFound();
            return player;
        }

        [HttpPost]
        public IActionResult Save([FromBody] PlayerServiceModel model)
        {
            biz.SavePlayer(model);
            return Ok("Player saved");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            biz.DeletePlayer(id);
            return Ok("Player deleted");
        }
    }
}