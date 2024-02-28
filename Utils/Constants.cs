using System.Collections.ObjectModel;

namespace ChuyenDoiSoServer.Utils;

public static class Constants
{
    public const string USER_SESSION = "UserSession";

    public const int PAGE_ITEM_COUNT = 10;

    public static readonly ReadOnlyCollection<string> ALLOW_LOGIN_ROLES = new(new List<string> { "Admin", "Chuyên gia", "Cộng tác viên", "Hiệp hội doanh nghiệp" });
}