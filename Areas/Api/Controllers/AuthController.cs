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

			if (string.IsNullOrEmpty(user.Password) || !PasswordHasher.Verify(login.Password, user.Password))
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

		[HttpPost("login-oauth")]
		[AllowAnonymous]
		public IActionResult LoginOAuth([FromBody] LoginOAuthModel login)
		{
			Console.WriteLine("=========================OAUTH=========================");
			string accessToken = "";
			User loginUser = null;
			var userLogin = _context.UserLogins
						.Where(x => x.ProviderKey == login.ProviderKey && x.ProviderName == login.ProviderName)
						.Include(l => l.User)
						.ThenInclude(u => u.Role)
						.FirstOrDefault();

			// tài khoản email này đã có liên kết user
			if (userLogin != null)
			{
				accessToken = _jwtServices.GenerateAccessToken(userLogin.User);
				loginUser = userLogin.User;
			}
			else
			{
				var u = _context.Users.Where(x => x.Email == login.Email).Include(x => x.Role).FirstOrDefault();
				// Nếu chưa có user 
				if (u == null)
				{
					return BadRequest(new
					{
						Code = "require_password_to_create",
						Message = "Nhập mật khẩu để tạo tài khoản mới",
					});

				}

				var newUserLogin = new UserLogin
				{
					ProviderKey = login.ProviderKey,
					ProviderName = login.ProviderName,
					User = u
				};
				_context.UserLogins.Add(newUserLogin);

				_context.SaveChanges();

				loginUser = u;
				accessToken = _jwtServices.GenerateAccessToken(u);
			}
			return Ok(new
			{
				UserProfile = new
				{
					loginUser.Id,
					loginUser.FirstName,
					loginUser.LastName,
					loginUser.Phone,
					loginUser.Email,
					avatar = AppPath.GenerateImagePath(AppPath.USER_PHOTO, loginUser.Photo),
					role = loginUser.Role.RoleName,
				},
				AccessToken = accessToken,
			});
		}


		[HttpPost("create-oauth-password")]
		[AllowAnonymous]
		public IActionResult CreateOAuthPassword([FromBody] CreateOAuthPasswordModel userInfo)
		{
			Console.WriteLine("======================Create OAuth Password=========================");
			var newUser = new User
			{
				FirstName = userInfo.FirstName,
				LastName = userInfo.LastName,
				Email = userInfo.Email,
				Role = _context.Roles.FirstOrDefault(x => x.Id == 2),
				Password = PasswordHasher.Hash(userInfo.Password),
			};
			_context.Users.Add(newUser);
			_context.SaveChanges();
			return Ok("Create user successfully");
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
