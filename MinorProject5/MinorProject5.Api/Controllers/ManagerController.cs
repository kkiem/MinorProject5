using Microsoft.AspNetCore.Mvc;
using MinorProject5.Api.Business;
using MinorProject5.Api.Models;

namespace MinorProject5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private BusinessLayer biz = new BusinessLayer();

        [HttpGet]
        public List<ManagerServiceModel> GetAll()
        {
            return biz.GetManagers();
        }

        [HttpGet("{id}")]
        public ActionResult<ManagerServiceModel> GetById(int id)
        {
            ManagerServiceModel? manager = biz.GetManager(id);
            if (manager == null) return NotFound();
            return manager;
        }

        [HttpPost]
        public IActionResult Save([FromBody] ManagerServiceModel model)
        {
            biz.SaveManager(model);
            return Ok("Manager saved");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            biz.DeleteManager(id);
            return Ok("Manager deleted");
        }
    }
}