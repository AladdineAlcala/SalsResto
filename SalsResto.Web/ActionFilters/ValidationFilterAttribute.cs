using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SalsResto.Data;

namespace SalsResto.Web.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;
        public ValidationFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(t => t.Value.ToString().Contains("DTO")).Value;
            //var param = context.ActionArguments;

            if (param == null)
            {
                _logger.LogError("Customer for creation return empty parameter");

                context.Result = new BadRequestObjectResult($"Object Creation is null controller {controller} : action {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object controller {controller}");

                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
       
            }

        }
    }
}
