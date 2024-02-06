using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.DoanhNghiep.RequestModel;
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
    public class DoanhNghiepController : ControllerBase
    {
        private readonly ChuyendoisoContext _context;
        public DoanhNghiepController(ChuyendoisoContext context)
        {
            _context = context;
        }

        [HttpGet("linhvuc")]
        public IActionResult LayLinhVucDN()
        {
            return Ok(_context.Linhvucs.Select(lv => new
            {
                Id = lv.Id,
                TenLinhVuc = lv.Tenlinhvuc
            }).ToList());
        }

        [HttpGet("loaihinh")]
        [AllowAnonymous]
        public IActionResult LayLoaiHinhDN()
        {
            return Ok(_context.DoanhnghiepLoaihinhs.Select(lv => new
            {
                Id = lv.Id,
                TenLoaiHinh = lv.Tenloaihinh
            }).ToList());
        }

        [HttpGet("info")]
        public IActionResult LayThongTinDN()
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


        public class TestModel
        {
            public IFormFile Image { get; set; }
        }

        [HttpPost("test")]
        [AllowAnonymous]
        public IActionResult Test([FromForm] TestModel model)
        {
            Console.WriteLine("========== TEST ==========");
            var imgName = CommonUtils.UploadImage(CommonUtils.CCCD, new IFormFile[] { model.Image })[0];
            Console.WriteLine("========== NAME: {0} ==========", imgName);
            return Ok();
        }
    }
}
