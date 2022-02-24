using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionList.Shared.Dto.Queries;

namespace SanctionList.Server.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchingMethodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchingMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllMatchingMethodQuery());
            return Ok(response);
        }
    }
}
