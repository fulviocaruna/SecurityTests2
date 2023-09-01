using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/csp-report")]
    public class CSPCollectApiController : ControllerBase
    {

        [HttpPost]
        public object GetData(object notify)
        {
            return notify;
        }
    }
}