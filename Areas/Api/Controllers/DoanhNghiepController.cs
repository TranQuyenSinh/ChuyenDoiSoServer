using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.DoanhNghiep.RequestModel;
using ChuyenDoiSoServer.Api.DoanhNghiep.ResponseModel;
using ChuyenDoiSoServer.Api.Models;
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
            return Ok(_context.Linhvuc.Select(lv => new
            {
                Id = lv.Id,
                TenLinhVuc = lv.Tenlinhvuc
            }).ToList());
        }

        [HttpGet("loaihinh")]
        [AllowAnonymous]
        public IActionResult LayLoaiHinhDN()
        {
            return Ok(_context.DoanhnghiepLoaihinh
                    .Select(lh => new LoaiHinhModel(lh)).ToList());
        }

        [HttpGet("doanhnghiep-info")]
        public IActionResult LayThongTinDoanhNghiep()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == UserUtils.GetUserId(User));
            if (user == null)
                return BadRequest(new
                {
                    Code = "user_not_found",
                    Message = "Không tìm thấy user"
                });

            var doanhnghiep = _context.Doanhnghiep
                                .Where(x => x.UserId == user.Id)
                                .Include(x => x.DoanhnghiepLoaihinh)
                                .Include(x => x.DoanhnghiepSdt)
                                .Include(x => x.User)
                                .Select(x => new DoanhNghiepModel(x))
                                .FirstOrDefault();

            return Ok(doanhnghiep);
        }
    }
}
