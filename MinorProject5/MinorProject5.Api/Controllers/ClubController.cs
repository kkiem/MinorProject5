using Microsoft.AspNetCore.Mvc;
using MinorProject5.Api.Business;
using MinorProject5.Api.Models;

namespace MinorProject5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private BusinessLayer biz = new BusinessLayer();

        [HttpGet]
        public List<ClubServiceModel> GetAll()
        {
            return biz.GetClubs();
        }

        [HttpGet("{id}")]
        public ActionResult<ClubServiceModel> GetById(int id)
        {
            ClubServiceModel? club = biz.GetClub(id);
            if (club == null) return NotFound();
            return club;
        }

        [HttpPost]
        public IActionResult Save([FromBody] ClubServiceModel model)
        {
            biz.SaveClub(model);
            return Ok("Club saved");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            biz.DeleteClub(id);
            return Ok("Club deleted");
        }
    }
}