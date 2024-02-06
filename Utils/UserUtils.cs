using System.Security.Claims;

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
}