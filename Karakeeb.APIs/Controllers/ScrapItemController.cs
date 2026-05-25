using Karakeeb.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karakeeb.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapItemController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetScrapItems()
        {
            var result = await mediator.Send(new GetScrapItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScrapItemById(int id)
        {
            var result = await mediator.Send(new GetScrapItemById(id));
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
