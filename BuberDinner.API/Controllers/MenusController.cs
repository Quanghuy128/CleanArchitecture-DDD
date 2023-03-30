using BuberDinner.Application.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly ISender _mediator;

        private readonly IMapper _mapper;
        public MenusController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMenu(
            CreateMenuRequest request,    
            string hostId
        )
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var createMenuResult = await _mediator.Send(command);
            return createMenuResult.Match(
                    createMenuResult => Ok(_mapper.Map<MenuResponse>(createMenuResult)),
                    errors => Problem(errors)
                );
        }
    }
}
