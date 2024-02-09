namespace ChuyenDoiSoServer.Utils;

public static class AppPath
{
    public const string USER_PHOTO = "/contents/user_photo/";
    public const string TIN_TUC_PHOTO = "/contents/tin_tuc/";
    public const string LOAI_HINH_PHOTO = "/contents/loai_hinh/";


    public static string GenerateImagePath(string type, string? image)
    {
        if (string.IsNullOrEmpty(image))
            return null;

        string rootPath = Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL");
        string imagePath = Path.Combine(type, image);

        return rootPath + imagePath;
    }
}