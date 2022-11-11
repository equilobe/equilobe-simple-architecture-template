using Equilobe.Microservice.Core.Attributes.Swagger;
using FluentValidation;

namespace Equilobe.SimpleArchitecture.Features.Users;

public class CreateUser
{
    public class Command : IRequest<string>
    {
        [SwaggerIgnore]
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, string>
    {
        public Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            //TODO: implement logic here + database
            return Task.FromResult(command.Id);
        }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}