using Microsoft.AspNetCore.Mvc;

namespace BAS.AuditJournal.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult NotAuthorized()
        {
            return Unauthorized();
        }
    }
}
