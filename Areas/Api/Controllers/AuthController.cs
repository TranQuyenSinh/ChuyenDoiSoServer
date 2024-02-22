﻿using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChuyenDoiSoServer.Api.Auth.RequestModel;
using ChuyenDoiSoServer.Api.DoanhNghiep.RequestModel;
using ChuyenDoiSoServer.Api.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Services;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace ChuyenDoiSoServer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ChuyendoisoContext _context;
		private readonly IConfiguration _configuration;
		private readonly JwtServices _jwtServices;
		private readonly IEmailSender _emailSender;
		public AuthController(ChuyendoisoContext context, IConfiguration configuration, JwtServices jwtServices, IEmailSender emailSender)
		{
			_context = context;
			_configuration = configuration;
			_jwtServices = jwtServices;
			_emailSender = emailSender;
		}
		[HttpPost("login-password")]
		[AllowAnonymous]
		public IActionResult LoginWithPassword([FromBody] LoginModel login)
		{
			var user = _context.Users
						.Include(u => u.UserVaitro)
						.ThenInclude(x => x.Vaitro)
						.Where(x => x.Email == login.Email).FirstOrDefault();
			string code, message;
			(code, message) = ValidateUser(user);
			if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(message))
			{
				return BadRequest(new { code, message });
			}

			if (string.IsNullOrEmpty(user.Password) || !BC.Verify(login.Password, user.Password))
				return BadRequest(new
				{
					code = "incorrect_password",
					message = "Sai mật khẩu"
				});
			return Ok(new
			{
				UserProfile = new UserModel(user),
				AccessToken = _jwtServices.GenerateAccessToken(user)
			});
		}

		[HttpPost("login-no-password")]
		[AllowAnonymous]
		public async Task<IActionResult> LoginNoPassword([FromBody] LoginNoPasswordModel model)
		{
			string accessToken = "";
			var user = _context.Users
						.Where(x => x.Email == model.Email)
						.Include(u => u.UserVaitro)
						.ThenInclude(x => x.Vaitro)
						.FirstOrDefault();
			string code, message;
			(code, message) = ValidateUser(user);
			if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(message))
			{
				return BadRequest(new { code, message });
			}

			return Ok(new
			{
				UserProfile = new UserModel(user),
				AccessToken = _jwtServices.GenerateAccessToken(user),
			});

		}

		private static (string, string) ValidateUser(Users? user)
		{
			string code = "", message = "";
			if (user == null)
			{
				code = "email_not_found";
				message = "Email không tồn tại trong hệ thống";
			}
			else if (user.EmailVerifiedAt == null)
			{
				code = "email_not_verified";
				message = "Email chưa xác nhận";
			}
			else if (user.Status.ToLower() == "inactive")
			{
				code = "wating_for_approval";
				message = "Tài khoản đang chờ xét duyệt";
			}
			return (code, message);
		}

		[HttpPost("register")]
		public async Task<IActionResult> DangKyThongTinDN([FromForm] DangKyModel model)
		{
			using var transaction = _context.Database.BeginTransaction();
			try
			{
				var verifyToken = Guid.NewGuid().ToString();

				if (_context.Users.Any(x => x.Email == model.Email))
				{
					Console.WriteLine("========== EMAIL ĐÃ TỒN TẠI ==========");
					return BadRequest(new
					{
						Code = "email_existed",
						Message = "Email đăng ký đã tồn tại"
					});
				}

				var user = new Users
				{
					Name = model.Name,
					Email = model.Email,
					Password = BC.HashPassword(model.Password, 10),
					Status = "Inactive",
					RememberToken = verifyToken,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				};
				_context.Add(user);
				_context.SaveChanges();

				_context.UserVaitro.Add(new UserVaitro { User = user, VaitroId = "dn" });
				_context.SaveChanges();

				var doanhNghiep = new Doanhnghiep
				{
					UserId = user.Id,
					DoanhnghiepLoaihinhId = model.LoaiHinhId,
					Tentienganh = model.TenTiengAnh,
					Tentiengviet = model.TenTiengViet,
					Tenviettat = model.TenVietTat,
					Diachi = model.DiaChiDN,
					Mathue = model.MaSoThue,
					Fax = model.Fax,
					Soluongnhansu = model.SoLuongNhanSu,
					Ngaylap = model.NgayLap,
					Mota = model.MoTa,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				};

				_context.Doanhnghiep.Add(doanhNghiep);
				_context.SaveChanges();

				model.DienThoaiDN.ForEach(sdt =>
				{
					_context.DoanhnghiepSdt.Add(
						new DoanhnghiepSdt
						{
							Sdt = sdt.Sdt,
							Loaisdt = sdt.Loaisdt,
							DoanhnghiepId = doanhNghiep.Id
						});
				});
				_context.SaveChanges();

				var daiDienDN = new DoanhnghiepDaidien
				{
					DoanhnghiepId = doanhNghiep.Id,
					Tendaidien = model.TenNguoiDaiDien,
					Email = model.EmailDD,
					Sdt = model.DienThoaiDD,
					Diachi = model.DiaChiDD,
					Cccd = model.Cccd,
					ImgMattruoc = CommonUtils.UploadImage(CommonUtils.CCCD, new IFormFile[] { model.ImgMatTruoc })[0],
					ImgMatsau = CommonUtils.UploadImage(CommonUtils.CCCD, new IFormFile[] { model.ImgMatSau })[0],
					Chucvu = model.ChucVu,
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now
				};
				_context.DoanhnghiepDaidien.Add(daiDienDN);
				_context.SaveChanges();
				transaction.Commit();

				// Gửi mail xác nhận
				string subject, body;
				(subject, body) = EmailUtils.TaoMailKichHoat(user.Id, verifyToken);
				await _emailSender.SendEmailAsync(user.Email, subject, body);
			}
			catch (DbUpdateException e)
			{
				transaction.Rollback();
				Console.WriteLine("========== ROLLBACK ==========");
				if (e.InnerException.Message.Contains("for key 'doanhnghiep_daidien_email_unique'"))
					return BadRequest(new
					{
						Code = "email_daidien_unique",
						Message = "Email đại diện doanh nghiệp đã tồn tại"
					});
				else throw new Exception();
			}
			catch (Exception e)
			{
				transaction.Rollback();
				Console.WriteLine("========== ROLLBACK: {0}  ==========", e.Message);
				return BadRequest(new
				{
					Code = "unknown",
					Message = "Có lỗi xảy ra"
				});
			}
			return Ok("OK");
		}


	}
}
