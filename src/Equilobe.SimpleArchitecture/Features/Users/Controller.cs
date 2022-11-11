using Equilobe.Microservice.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Equilobe.SimpleArchitecture.Features.Users;

[Route("api/users")]
public class Controller : ControllerBase
{
    private IMediator _mediator;

    public Controller(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<Page<GetUserPage.UserSummaryReadModel>> GetUserPageAsync(GetUserPage.Query query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<string> CreateUserAsync(CreateUser.Command command)
    {
        command.Id = Guid.NewGuid().ToString();

        return await _mediator.Send(command);
    }
}
