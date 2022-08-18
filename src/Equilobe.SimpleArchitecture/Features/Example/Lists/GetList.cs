using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Equilobe.SimpleArchitecture.Features.Example.Lists
{
    public class GetList
    {
        public class Query : IRequest<IEnumerable<string>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<string>>
        {

            public async Task<IEnumerable<string>> Handle(Query query, CancellationToken token)
            {
                return new string[1] { "Test list item" };
            }
        }
    }
}
