using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equilobe.SimpleArchitecture.Features.Example.Lists
{
    [Route("api/test/lists")]
    public class Controller : ControllerBase
    {
        private IMediator _mediator;
        private ILogger<Controller> _logger;

        public Controller(IMediator mediator, ILogger<Controller> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Query(GetList.Query query)
        {
            return await _mediator.Send(query);
        }
    }
}
