using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Data;
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
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		private readonly JwtServices _jwtServices;
		public AuthController(ApplicationDbContext context, IConfiguration configuration, JwtServices jwtServices)
		{
			_context = context;
			_configuration = configuration;
			_jwtServices = jwtServices;
		}
		[HttpPost("login-password")]
		[AllowAnonymous]
		public IActionResult LoginWithPassword([FromBody] LoginModel login)
		{
			Console.WriteLine("AUTH");
			var user = _context.Users
						.Include(u => u.Role)
						.Where(x => x.Email == login.Email).FirstOrDefault();
			if (user == null)
				return BadRequest(new
				{
					code = "email_not_found",
					message = "Email không tồn tại trong hệ thống"
				});

			// if (!PasswordHasher.Verify(login.Password, user.Password))
			// 	return BadRequest(new
			// 	{
			// 		code = "incorrect_password",
			// 		message = "Sai mật khẩu"
			// 	});

			// Generate JWT
			var token = _jwtServices.GenerateAccessToken(user);

			return Ok(new
			{
				UserProfile = new
				{
					user.Id,
					user.FirstName,
					user.LastName,
					user.Phone,
					user.Email,
					avatar = AppPath.GenerateImagePath(AppPath.USER_PHOTO, user.Photo),
					role = user.Role.RoleName,
				},
				AccessToken = token,
			});
		}

		[HttpGet("Test")]
		public IActionResult Test()
		{
			Console.WriteLine("CC");
			return BadRequest(new
			{
				Code = "Invalid_token",
				Message = "Token hết hạn"
			});
		}

	}
}
