using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TaskManagement.API.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var executionTime = _stopwatch.ElapsedMilliseconds;
            context.HttpContext.Response.Headers.Append("X-Execution-Time-ms", executionTime.ToString());
        }
    }
}
