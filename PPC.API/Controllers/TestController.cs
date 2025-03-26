using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AC_PPC.API.Controllers
{
    //[Authorize]
    //[ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Is OK.");// View();
        }

    }
}
