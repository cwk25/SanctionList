using MediatR;
using Microsoft.AspNetCore.Mvc;
using SanctionList.Shared.Dto.Queries;

namespace SanctionList.Server.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlacklistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlacklistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("match")]
        public async Task<IActionResult> Get(GetBlacklistedCustomerQuery request)
        {
            var response = await _mediator.Send(request);
            //Thread.Sleep(3000);
            return Ok(response);
        }
    }
}
