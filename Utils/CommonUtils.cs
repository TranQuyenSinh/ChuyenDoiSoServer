using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.VisualBasic;

namespace ChuyenDoiSoServer.Utils;

public static class CommonUtils
{
    public const string CCCD = "Uploads/daidien_doanhnghiep/cccd";
    public const string USER_PHOTO = "Uploads/user_photo/";
    public const string TIN_TUC_PHOTO = "Uploads/tin_tuc/";
    public const string LOAI_HINH_PHOTO = "Uploads/loai_hinh/";
    public const string LINH_VUC_PHOTO = "Uploads/linh_vuc/";

    public static List<string> UploadImage(string type, IFormFile[] files)
    {
        List<string> fileNames = new();
        foreach (var image in files)
        {
            string imgName = null;
            if (image != null)
            {
                imgName = Path.GetFileName(Path.GetRandomFileName()) + Path.GetExtension(image.FileName);
                var uploadPath = Path.Combine(type, imgName);

                // resize the image
                // var width = Const.STORY_THUMB_WIDTH;
                // var height = Const.STORY_THUMB_HEIGHT;
                // Image img = Image.FromStream(file.OpenReadStream());
                // var cutImg = new Bitmap(img, width, height);

                try
                {
                    using var fs = new FileStream(uploadPath, FileMode.Create);
                    image.CopyTo(fs);
                    fileNames.Add(imgName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when uploading the file: {0}", image.FileName);
                    Console.WriteLine("Error message: {0}", e.Message);
                }
            }
        }

        return fileNames;
    }

    public static string UploadImage(string type, IFormFile file)
    {
        string fileName = "";
        if (file != null)
        {
            string imgName = Path.GetFileName(Path.GetRandomFileName()) + Path.GetExtension(file.FileName);
            var uploadPath = Path.Combine(type, imgName);

            // resize the image
            // var width = Const.STORY_THUMB_WIDTH;
            // var height = Const.STORY_THUMB_HEIGHT;
            // Image img = Image.FromStream(file.OpenReadStream());
            // var cutImg = new Bitmap(img, width, height);

            try
            {
                using var fs = new FileStream(uploadPath, FileMode.Create);
                file.CopyTo(fs);
                fileName = imgName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when uploading the file: {0}", file.FileName);
                Console.WriteLine("Error message: {0}", e.Message);
            }
        }

        return fileName;
    }

    public static void DeleteImage(string type, string fileName)
    {
        var removeFilePath = Path.Combine(type, fileName);
        try
        {
            File.Delete(removeFilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error when delete the file: {0}", removeFilePath);
            Console.WriteLine("Error message: {0}", e.Message);
        }
    }

    public static string GenerateSlug(string str, bool hierarchical = true)
    {
        var slug = str.Trim().ToLower();

        string[] decomposed = new string[] { "à","á","ạ","ả","ã","â","ầ","ấ","ậ","ẩ","ẫ","ă",
                                                    "ằ","ắ","ặ","ẳ","ẵ","è","é","ẹ","ẻ","ẽ","ê","ề" ,
                                                    "ế","ệ","ể","ễ", "ì","í","ị","ỉ","ĩ", "ò","ó","ọ",
                                                    "ỏ","õ","ô","ồ","ố","ộ","ổ","ỗ","ơ" ,"ò","ớ","ợ","ở",
                                                    "õ", "ù","ú","ụ","ủ","ũ","ư","ừ","ứ","ự","ử","ữ",
                                                    "ỳ","ý","ỵ","ỷ","ỹ", "đ",
                                                    "À","À","Ạ","Ả","Ã","Â","Ầ","Ấ","Ậ","Ẩ","Ẫ","Ă" ,
                                                    "Ằ","Ắ","Ặ","Ẳ","Ẵ", "È","É","Ẹ","Ẻ","Ẽ","Ê","Ề",
                                                    "Ế","Ệ","Ể","Ễ", "Ì","Í","Ị","Ỉ","Ĩ", "Ò","Ó","Ọ","Ỏ",
                                                    "Õ","Ô","Ồ","Ố","Ộ","Ổ","Ỗ","Ơ" ,"Ờ","Ớ","Ợ","Ở","Ỡ",
                                                    "Ù","Ú","Ụ","Ủ","Ũ","Ư","Ừ","Ứ","Ự","Ử","Ữ", "Ỳ","Ý","Ỵ",
                                                    "Ỷ","Ỹ", "Đ"};
        string[] precomposed =  {  "à","á","ạ","ả","ã","â","ầ","ấ","ậ","ẩ","ẫ","ă",
                                        "ằ","ắ","ặ","ẳ","ẵ","è","é","ẹ","ẻ","ẽ","ê","ề" ,
                                        "ế","ệ","ể","ễ", "ì","í","ị","ỉ","ĩ", "ò","ó","ọ","ỏ",
                                        "õ","ô","ồ","ố","ộ","ổ","ỗ","ơ" ,"ờ","ớ","ợ","ở","ỡ", "ù",
                                        "ú","ụ","ủ","ũ","ư","ừ","ứ","ự","ử","ữ", "ỳ","ý","ỵ","ỷ","ỹ",
                                        "đ", "À","Á","Ạ","Ả","Ã","Â","Ầ","Ấ","Ậ","Ẩ","Ẫ","Ă" ,"Ằ","Ắ",
                                        "Ặ","Ẳ","Ẵ", "È","É","Ẹ","Ẻ","Ẽ","Ê","Ề","Ế","Ệ","Ể","Ễ", "Ì",
                                        "Í","Ị","Ỉ","Ĩ", "Ò","Ó","Ọ","Ỏ","Õ","Ô","Ồ","Ố","Ộ","Ổ","Ỗ",
                                        "Ơ" ,"Ờ","Ớ","Ợ","Ở","Ỡ", "Ù","Ú","Ụ","Ủ","Ũ","Ư","Ừ","Ứ","Ự",
                                        "Ử","Ữ", "Ỳ","Ý","Ỵ","Ỷ","Ỹ", "Đ"};
        string[] latin =  { "a","a","a","a","a","a","a","a","a","a","a" ,
                                "a","a","a","a","a","a", "e","e","e","e","e",
                                "e","e","e","e","e","e", "i","i","i","i","i", "o",
                                "o","o","o","o","o","o","o","o","o","o","o" ,"o","o","o","o","o",
                                "u","u","u","u","u","u","u","u","u","u","u", "y","y","y","y","y", "d",
                                "a","a","a","a","a","a","a","a","a","a","a","a" ,"a","a","a","a","a",
                                "e","e","e","e","e","e","e","e","e","e","e", "i","i","i","i","i", "o",
                                "o","o","o","o","o","o","o","o","o","o","o" ,"o","o","o","o","o", "u",
                                "u","u","u","u","u","u","u","u","u","u", "y","y","y","y","y", "d"};

        // Convert culture specific characters
        for (int i = 0; i < decomposed.Length; i++)
        {
            slug = slug.Replace(decomposed[i], latin[i]);
            slug = slug.Replace(precomposed[i], latin[i]);
        }

        // Remove special characters
        slug = Regex.Replace(slug, @"[^a-z0-9-/ ]", "").Replace("--", "-");

        // Remove whitespaces
        slug = Regex.Replace(slug.Replace("-", " "), @"\s+", " ").Replace(" ", "-");

        // Remove slash if non-hierarchical
        if (!hierarchical)
            slug = slug.Replace("/", "-");

        // Remove multiple dashes
        slug = Regex.Replace(slug, @"[-]+", "-");

        // Remove leading & trailing dashes
        if (slug.EndsWith("-"))
            slug = slug.Substring(0, slug.LastIndexOf("-"));
        if (slug.StartsWith("-"))
            slug = slug.Substring(Math.Min(slug.IndexOf("-") + 1, slug.Length));
        return slug;
    }
}
