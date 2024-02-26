using System.Security.Claims;
using ChuyenDoiSoServer.Admin.Models;
using Newtonsoft.Json;

namespace ChuyenDoiSoServer.Utils;

public static class UserUtils
{
    public static ulong GetUserId(ClaimsPrincipal User)
    {
        var userIdClaim = User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        if (!string.IsNullOrEmpty(userIdClaim))
        {
            return ulong.Parse(userIdClaim);
        }
        return 0;
    }

    public static ulong? GetUserId(ISession session)
    {
        var userSession = session.GetString(Constants.USER_SESSION);
        if (userSession == null)
            return 0;
        var user = JsonConvert.DeserializeObject<UserSession>(userSession);
        return user.Id;
    }
}