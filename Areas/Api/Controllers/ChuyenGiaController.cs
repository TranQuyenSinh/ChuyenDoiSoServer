using ChuyenDoiSoServer.Api.Auth.RequestModel;
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
        public async Task<IActionResult> Index()
        {
            var data = await _context.Chuyengia
                                .Include(x => x.User)
                                .Include(x => x.Linhvuc)
                                .ToListAsync();
            return Ok(data);
        }
    }
}
