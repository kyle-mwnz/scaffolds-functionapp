using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Example.Function
{
    public class httpGetFunction
    {
        private readonly ILogger _logger;

        public httpGetFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<httpGetFunction>();
        }

        [Function("httpget")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")]
          HttpRequest req,
          string name)
        {
            var returnValue = string.IsNullOrEmpty(name)
                ? "Hello, World."
                : $"Hello, {name}.";
 
            _logger.LogInformation($"{{slug}} C# HTTP trigger function processed a request for {returnValue}.");
 
            var payload = new
            {
                message = returnValue
            };

            return new JsonResult(payload);
        }
    }

}
