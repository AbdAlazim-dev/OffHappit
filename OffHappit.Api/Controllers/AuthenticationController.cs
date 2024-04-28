using Microsoft.AspNetCore.Mvc;

namespace OffHappit.Api.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthenticationController : Controller
    {
        public ActionResult<string> Login()
        {
            return "Hello World";
        }
        public ActionResult<string> Register()
        {
            return "Hello World";
        }
    }
}
