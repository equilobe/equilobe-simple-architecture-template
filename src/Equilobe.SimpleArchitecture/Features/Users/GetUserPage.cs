using Equilobe.Microservice.Core.Models;

namespace Equilobe.SimpleArchitecture.Features.Users;

public class GetUserPage
{
    public class Query :
        IRequest<Page<UserSummaryReadModel>>,
        ISortFilter,
        IPageFilter
    {
        public string? SortBy { get; set; }
        public bool IsSortedAscending { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public string? Name { get; set; }
    }

    public class Handler : IRequestHandler<Query, Page<UserSummaryReadModel>>
    {
        public Task<Page<UserSummaryReadModel>> Handle(Query query, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Page<UserSummaryReadModel>(new List<UserSummaryReadModel> { new UserSummaryReadModel { Id = "1", FirstName = "John", LastName = "Doe" } }, 1));
        }
    }

    public class UserSummaryReadModel
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
