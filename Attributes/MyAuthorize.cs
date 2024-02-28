using ChuyenDoiSoServer.Admin.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ChuyenDoiSoServer.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyAuthorize : ActionFilterAttribute
{
    public string RoleNames;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userSession = context.HttpContext.Session.GetString(Constants.USER_SESSION);
        if (userSession == null)
        {
            context.Result = new RedirectResult("/admin/auth/login");
            return;
        }

        if (!string.IsNullOrEmpty(RoleNames))
        {
            var user = JsonConvert.DeserializeObject<UserSession>(userSession);
            var requiredRoles = RoleNames.Split(", ").ToList();

            if (!requiredRoles.Any(x => user.Roles.Contains(x)))
            {
                context.Result = new RedirectResult("/admin/auth/han-che-truy-cap");
                return;
            }
        }
    }
}