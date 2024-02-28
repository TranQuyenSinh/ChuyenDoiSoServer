using ChuyenDoiSoServer.Admin.Auth.RequestModels;
using ChuyenDoiSoServer.Admin.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using BC = BCrypt.Net.BCrypt;
namespace ChuyenDoiSoServer.Admin.Controllers;

[Route("admin/[controller]")]
[Area("Admin")]
public class AuthController : Controller
{
    private readonly ChuyendoisoContext _context;
    public AuthController(ChuyendoisoContext context)
    {
        _context = context;
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users
                                .Where(x => x.Email == model.Email)
                                .Include(x => x.UserVaitro)
                                .ThenInclude(x => x.Vaitro)
                                .FirstOrDefaultAsync();
            if (user != null && BC.Verify(model.Password, user.Password))
            {

                if (user.UserVaitro.ToList().All(uvt => !Constants.ALLOW_LOGIN_ROLES.Contains(uvt.Vaitro.Tenvaitro)))
                {
                    ModelState.AddModelError("", "Bạn không có quyền truy cập trang web này");
                    return View();
                }

                var userSession = new UserSession
                {
                    Id = user.Id,
                    Name = user.Name,
                    Image = AppPath.GenerateImagePath(AppPath.USER_PHOTO, user.Image, true),
                    Roles = user.UserVaitro.Select(x => x.Vaitro.Tenvaitro).ToList()
                };
                var json = JsonConvert.SerializeObject(userSession);
                HttpContext.Session.SetString(Constants.USER_SESSION, json);
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác");
            }

        }

        return View();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove(Constants.USER_SESSION);
        return RedirectToAction(nameof(Login));
    }

    [HttpGet("han-che-truy-cap")]
    public IActionResult HanCheTruyCap()
    {
        return View();
    }
}
