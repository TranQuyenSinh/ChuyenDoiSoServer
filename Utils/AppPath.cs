namespace ChuyenDoiSoServer.Utils;

public static class AppPath
{
    public const string USER_PHOTO = "/contents/user_photo/";
    public const string TIN_TUC_PHOTO = "/contents/tin_tuc/";
    public const string LOAI_HINH_PHOTO = "/contents/loai_hinh/";
    public const string LINH_VUC_PHOTO = "contents/linh_vuc/";
    public const string CCCD = "/contents/daidien_doanhnghiep/cccd/";

    public static string GenerateImagePath(string type, string? image, bool useLocalhost = false)
    {
        if (string.IsNullOrEmpty(image))
            return null;

        string rootPath = Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL");
        string imagePath = Path.Combine(type, image);

        return useLocalhost ? "https://localhost:8080" + imagePath : rootPath + imagePath;
    }
}