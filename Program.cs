using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ChuyenDoiSoServer.Services;
using ChuyenDoiSoServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChuyenDoiSoServer.Admin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ChuyendoisoContext>(options =>
{
	options.UseMySQL(builder.Configuration.GetConnectionString("ChuyenDoiSo"));
	options.ConfigureWarnings(warnings =>
		   warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
});

/* ================ Config Session ================ */
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.Cookie.Name = "ChuyenDoiSo";
	options.IdleTimeout = new TimeSpan(0, 60, 0);
});

/* ================ Send Mail Service ================ */
builder.Services.AddOptions();
var mailsettings = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsettings);
builder.Services.AddSingleton<IEmailSender, SendMailService>();

/* CORS */
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.WithOrigins("*")
					.AllowAnyHeader()
					.AllowAnyMethod();
		});
});

/* Identity JWT */
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidAudience = builder.Configuration["JWT:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Key),
		ClockSkew = TimeSpan.Zero
	};
});
builder.Services.AddAuthorization();

// my services
builder.Services.AddSingleton<JwtServices, JwtServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseCors();

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
	RequestPath = "/contents"
});

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
	name: "Map_Area",
	pattern: "{Area=Admin}/{controller=Home}/{action=Index}/{id?}", areaName: "Admin");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}",
	dataTokens: new { pathBase = "localhost" });
app.MapRazorPages();

app.Run();
