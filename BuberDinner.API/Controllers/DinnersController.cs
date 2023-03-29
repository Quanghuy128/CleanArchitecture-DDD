using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("api/[controller]")]
    
    public class DinnersController : ApiController
    {
        [HttpGet("dinners")]
        public IActionResult ListDinners()
        {
            return Ok(new[] { "asc", "asccc"});
        }
    }
}
