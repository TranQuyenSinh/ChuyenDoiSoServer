using ChuyenDoiSoServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChuyenDoiSoServer.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ChuyendoisoContext _context;

		public HomeController(ILogger<HomeController> logger, ChuyendoisoContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("kich-hoat")]
		public async Task<IActionResult> KichHoatTaiKhoan(ulong userId, string code)
		{
			var user = await _context.Users
						.Where(x => x.Id == userId && x.RememberToken == code)
						.FirstOrDefaultAsync();
			if (user == null)
				return BadRequest();

			user.EmailVerifiedAt = DateTime.Now;
			await _context.SaveChangesAsync();

			return View("KichHoatThanhCong");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}