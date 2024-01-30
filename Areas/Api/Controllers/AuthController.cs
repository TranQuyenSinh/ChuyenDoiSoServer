using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
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
		private readonly ChuyendoisoContext _context;
		private readonly IConfiguration _configuration;
		private readonly JwtServices _jwtServices;
		public AuthController(ChuyendoisoContext context, IConfiguration configuration, JwtServices jwtServices)
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
						.Include(u => u.UserVaitros)
						.ThenInclude(x => x.IdVaitroNavigation)
						.Where(x => x.Email == login.Email).FirstOrDefault();
			if (user == null)
				return BadRequest(new
				{
					code = "email_not_found",
					message = "Email không tồn tại trong hệ thống"
				});

			if (string.IsNullOrEmpty(user.Password) || !PasswordHasher.ValidateMD5(login.Password, user.Password))
				return BadRequest(new
				{
					code = "incorrect_password",
					message = "Sai mật khẩu"
				});

			// Generate JWT
			var token = _jwtServices.GenerateAccessToken(user);

			return Ok(new
			{
				UserProfile = new
				{
					user.Id,
					user.Email,
					roles = user.UserVaitros.Select(x => x.IdVaitroNavigation.Tenvaitro).ToList(),
				},
				AccessToken = token,
			});
		}

		[HttpPost("login-oauth")]
		[AllowAnonymous]
		public IActionResult LoginOAuth([FromBody] LoginOAuthModel model)
		{
			Console.WriteLine("=========================OAUTH=========================");
			string accessToken = "";
			var user = _context.Users
						.Where(x => x.Email == model.Email)
						.Include(u => u.UserVaitros)
						.ThenInclude(x => x.IdVaitroNavigation)
						.FirstOrDefault();

			if (user != null)
			{
				accessToken = _jwtServices.GenerateAccessToken(user);
			}
			else
			{
				user = new User
				{
					Hoten = model.HoTen,
					Email = model.Email,
					ProviderKey = model.ProviderKey,
					// UserVaitros = new Collection<UserVaitro>() {
					// 	new() {
					// 		IdUserNavigation = user,
					// 		IdVaitro = 2
					// 	}
					// }
				};
				_context.Users.Add(user);
				_context.SaveChanges();
			}

			return Ok(new
			{
				UserProfile = new
				{
					user.Id,
					user.Email,
					role = user.UserVaitros?.Select(x => x.IdVaitroNavigation.Tenvaitro).ToList(),
				},
				AccessToken = accessToken,
			});
		}

		[HttpPost("register")]
		[AllowAnonymous]
		public IActionResult Register([FromBody] RegisterModel model)
		{
			Console.WriteLine("========== REGISTER ==========");
			var isExistEmail = _context.Users.Any(x => x.Email == model.Email);
			if (isExistEmail)
			{
				return BadRequest(new
				{
					Code = "email_existed",
					Message = "Email đã tồn tại"
				});
			}
			var user = new User
			{
				Hoten = model.HoTen,
				Email = model.Email,
				Trangthai = 1,
				Password = PasswordHasher.GetMD5(model.Password)
			};
			_context.Add(user);
			_context.SaveChanges();
			// ADD ROLE LOGIC BELOW THIS
			return Ok("Sign up successfully");
		}
	}
}
