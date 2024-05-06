using BS.Application.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BS.Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiControllerBase
    {
        public DinnersController() { }

        [HttpGet]
        public IActionResult ListDinners() {
            return Ok(Array.Empty<string>());
        }
    }
}
