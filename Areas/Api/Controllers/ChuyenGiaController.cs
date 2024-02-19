using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.ChuyenGia.ResponseModel;
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
    public class ChuyenGiaController : ControllerBase
    {
        private readonly ChuyendoisoContext _context;
        public ChuyenGiaController(ChuyendoisoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery(Name = "linhVucId")] string linhVucId)
        {
            Console.WriteLine("========== Lấy DS Chuyên gia  ==========");
            var data = await _context.Chuyengia
                                .Where(x => x.LinhvucId == linhVucId)
                                .Include(x => x.Linhvuc)
                                .Include(x => x.User)
                                .Select(x => new ChuyenGiaModel(x))
                                .ToListAsync();
            return Ok(data);
        }
    }
}
