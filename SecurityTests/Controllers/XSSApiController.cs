using Microsoft.AspNetCore.Mvc;

namespace SecurityTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XSSApiController : ControllerBase
    {
        public List<string> GetData(string searchTerm)
        {
            return new List<string>() {
searchTerm + " 1",
searchTerm + " 2",
searchTerm + " 3"
};
        }
    }
}