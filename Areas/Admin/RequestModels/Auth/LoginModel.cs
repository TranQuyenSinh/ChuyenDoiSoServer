using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChuyenDoiSoServer.Admin.Auth.RequestModels;

public class LoginModel
{
    [Required(ErrorMessage = "{0} không được bỏ trống")]
    [DisplayName("Email")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "{0} không đúng định dạng")]
    public string Email { get; set; }

    [Required(ErrorMessage = "{0} không được bỏ trống")]
    [DisplayName("Mật khẩu")]
    public string Password { get; set; }
}