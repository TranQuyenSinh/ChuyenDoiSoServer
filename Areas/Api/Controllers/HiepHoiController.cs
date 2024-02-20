using System.Net;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.HiepHoi.ResponseModel;
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
    public class HiepHoiController : ControllerBase
    {
        private readonly ChuyendoisoContext _context;
        public HiepHoiController(ChuyendoisoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var hiephois = await _context.Hiephoidoanhnghiep
                            .Include(x => x.HiephoidoanhnghiepDaidien)
                            .Select(x => new HiepHoiDoanhNghiepModel(x))
                            .ToListAsync();

            return Ok(hiephois);
        }
    }
}
