using Microsoft.Extensions.Logging;

namespace LoggerScopeSample.Controllers
{
    public class MyService
    {
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
        }

        public string Test()
        {
            _logger.LogTrace("log: test");
            return "Test";
        }
    }
}