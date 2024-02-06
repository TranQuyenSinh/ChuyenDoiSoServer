using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

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
            var user = _context.Users.Find(UserUtils.GetUserId(User));
            if (user == null) return BadRequest(new
            {
                Code = "user_not_found",
                Message = "Không tìm thấy user"
            });

            if (!string.IsNullOrEmpty(user.Password) && !BC.Verify(model.CurrentPassword, user.Password))
                return BadRequest(new
                {
                    Code = "password_not_match",
                    Message = "Sai mật khẩu"
                });

            user.Password = BC.HashPassword(model.NewPassword);
            _context.SaveChanges();
            return Ok("Thay đổi mật khẩu thành công");
        }
    }
}
