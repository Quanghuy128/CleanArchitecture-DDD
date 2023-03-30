using BuberDinner.Contracts.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        [HttpPost("create-menu")]
        public IActionResult CreateMenu(
            CreateMenuRequest request,    
            string hostId
        )
        {
            return Ok(request);
        }
    }
}
