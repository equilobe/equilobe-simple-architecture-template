using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Equilobe.SimpleArchitecture.Common.Logging
{
    public class LoggingRequestPreprocessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private static readonly JsonSerializerSettings LoggingJsonSettings;

        private readonly ILogger _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        static LoggingRequestPreprocessor()
        {
            LoggingJsonSettings = new JsonSerializerSettings
            {
                // using a custome resolver to ignore properties during logging
                // [JsonIgnore] is not used since it affects model binding
                ContractResolver = new LoggingJsonResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None
            };
        }

        public LoggingRequestPreprocessor(ILogger<TRequest> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Not Present";
            var type = request.GetType().FullName.Replace("+", ".");
            var json = JsonConvert.SerializeObject(request, LoggingJsonSettings);

            _logger.LogInformation($"Handling a request: Type={type}; Request={json}; User={currentUser}");

            return Unit.Task;
        }
    }
}
