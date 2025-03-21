using Microsoft.AspNetCore.Mvc;

namespace AC_PPC.API.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Is OK.");// View();
        }
    }
}
