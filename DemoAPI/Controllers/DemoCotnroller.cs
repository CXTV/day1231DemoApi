using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/demo")]
    [Authorize(Roles = "admin")]
    public class DemoCotnroller:ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("只有 Admin 角色可以访问！");
        }
    }
}
