using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OffHappit.Api.Controllers
{
    [ApiController]
    [Route("api/happits")]
    public class HappitsController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Ok("Authorized user");
        }
    }
}
