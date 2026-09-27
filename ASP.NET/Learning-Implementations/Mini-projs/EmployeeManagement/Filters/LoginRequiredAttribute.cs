using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.Filters
{
    /// <summary>
    /// Custom action filter that checks whether a user is logged in (via Session).
    /// Apply to controllers/actions that require authentication:
    ///     [LoginRequired]
    ///     public class EmployeeController : Controller { ... }
    /// </summary>
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string username = context.HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
