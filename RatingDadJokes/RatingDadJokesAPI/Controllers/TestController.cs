using Microsoft.AspNetCore.Mvc;

namespace RatingDadJokesAPI.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
            
        }

        [HttpGet]
        public async Task<string> TestMethod()
        {
            return "SERVICE RUNNING";
        }
    }
}
