using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Utils
{
    public class ExampleFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }
        public void OnActionExecuting(ActionExecutingContext context){ }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
