using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ChuyenDoiSoServer.Admin.Controllers
{
    public class AuthorizeController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString(Constants.USER_SESSION) == null)
            {
                filterContext.Result = new RedirectResult("/admin/auth/login");
            }
        }
    }

    public class RoleName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}