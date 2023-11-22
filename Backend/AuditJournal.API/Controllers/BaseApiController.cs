using BAS.AuditJournal.Filter;
using Microsoft.AspNetCore.Mvc;

namespace BAS.AuditJournal.API.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
