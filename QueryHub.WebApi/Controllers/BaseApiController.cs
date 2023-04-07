using Microsoft.AspNetCore.Mvc;
using QueryHub.WebApi.Filter;

namespace QueryHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}