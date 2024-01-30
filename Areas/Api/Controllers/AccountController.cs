using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Services;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChuyenDoiSoServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ChuyendoisoContext _context;
        public AccountController(ChuyendoisoContext context)
        {
            _context = context;
        }

        [HttpGet("has-password")]
        public IActionResult CheckUserIsHasPassword()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserUtils.GetUserId(User));
            if (user == null)
                return BadRequest(new
                {
                    Code = "user_not_found",
                    Message = "Không tìm thấy user"
                });

            return Ok(!string.IsNullOrEmpty(user.Password));
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            Console.WriteLine("========== CHANGE PASSWORD ==========");
            var userId = UserUtils.GetUserId(User);
            var user = _context.Users.Find(userId);
            if (user == null) return BadRequest(new
            {
                Code = "user_not_found",
                Message = "Không tìm thấy user"
            });

            if (!string.IsNullOrEmpty(user.Password) && !PasswordHasher.ValidateMD5(model.CurrentPassword, user.Password))
                return BadRequest(new
                {
                    Code = "password_not_match",
                    Message = "Sai mật khẩu"
                });

            user.Password = PasswordHasher.GetMD5(model.NewPassword);
            _context.SaveChanges();
            return Ok("Thay đổi mật khẩu thành công");
        }
    }
}
