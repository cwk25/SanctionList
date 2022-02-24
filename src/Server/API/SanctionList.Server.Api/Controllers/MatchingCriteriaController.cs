using MediatR;
using Microsoft.AspNetCore.Mvc;
using SanctionList.Shared.Dto.Commands;
using SanctionList.Shared.Dto.Queries;

namespace SanctionList.Server.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchingCriteriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchingCriteriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetMatchingCriteriaQuery());

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateMatchingCriteriaCommand request)
        {
            var response = await _mediator.Send(request);

            return NoContent();
        }
    }
}
