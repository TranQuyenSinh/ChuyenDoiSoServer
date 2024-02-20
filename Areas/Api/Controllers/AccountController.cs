using System.Net;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _context.Users
                        .Where(x => x.Id == UserUtils.GetUserId(User))
                        .Include(x => x.UserVaitro)
                        .ThenInclude(x => x.Vaitro)
                        .FirstOrDefaultAsync();

            if (user == null)
                return BadRequest(new
                {
                    Code = "user_not_found",
                    Message = "Không tìm thấy user"
                });

            return Ok(new UserModel(user));
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
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

        [HttpPost("change-avatar")]
        public IActionResult ChangeAvatar([FromForm] ChangeAvatarModel model)
        {
            var user = _context.Users.Find(UserUtils.GetUserId(User));
            if (user == null) return BadRequest(new
            {
                Code = "user_not_found",
                Message = "Không tìm thấy user"
            });

            if (!string.IsNullOrEmpty(user.Image))
            {
                CommonUtils.DeleteImage(CommonUtils.USER_PHOTO, user.Image);
            }
            var newImageName = CommonUtils.UploadImage(CommonUtils.USER_PHOTO, model.Avatar);

            user.Image = newImageName;
            _context.SaveChanges();
            return Ok("Thay đổi ảnh đại diện thành công");
        }
    }
}
