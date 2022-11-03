using Microsoft.AspNetCore.Mvc;

namespace Employee.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BaseApiController : ControllerBase
    {
    }
}
