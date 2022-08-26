using MediatR;

namespace Equilobe.SimpleArchitecture.Features.Example.Lists;

public class GetList
{
    public class Query : IRequest<IEnumerable<string>>
    {
    }

    public class Handler : IRequestHandler<Query, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(Query query, CancellationToken token)
        {
            return await Task.FromResult(new string[1] { "Test list item" });
        }
    }
}
