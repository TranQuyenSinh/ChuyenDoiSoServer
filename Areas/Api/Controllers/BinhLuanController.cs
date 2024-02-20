using ChuyenDoiSoServer.Api.BinhLuan.RequestModel;
using ChuyenDoiSoServer.Api.TinTuc.ResponseModel;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuyenDoiSoServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BinhLuanController : ControllerBase
{
    private readonly ChuyendoisoContext _context;

    public BinhLuanController(ChuyendoisoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBinhLuanByTinTucId([FromQuery(Name = "tinTucId")] ulong tinTucId)
    {
        var tinTucExist = _context.Tintuc.Any(x => x.Id == tinTucId);

        if (!tinTucExist)
            return BadRequest(new
            {
                Code = "tuctuc_not_found",
                Message = "Không tìm thấy tin tức"
            });


        var binhLuans = _context.Binhluan
                            .Where(x => x.TintucId == tinTucId && x.BinhluanId == null)
                            .Include(x => x.User)
                            .Include(x => x.InverseBinhluanNavigation)
                            .ThenInclude(x => x.User)
                            .OrderByDescending(x => x.Ngaydang)
                            .Select(x => new BinhLuanModel(x))
                            .ToList();

        return new JsonResult(binhLuans);
    }

    [HttpPost]
    public IActionResult ThemBinhLuan([FromBody] ThemBinhLuanModel model)
    {
        var userExist = _context.Users.Any(x => x.Id == model.UserId);
        var newsExitst = _context.Tintuc.Any(x => x.Id == model.TinTucId);

        if (!userExist) return BadRequest(new
        {
            Code = "user_not_found",
            Message = "Không tìm thấy người dùng, id = " + model.UserId
        });
        if (!newsExitst) return BadRequest(new
        {
            Code = "news_not_found",
            Message = "Không tìm thấy tin tức, id = " + model.TinTucId
        });

        var binhLuan = new Binhluan
        {
            Noidung = model.NoiDung,
            TintucId = model.TinTucId,
            UserId = model.UserId,
            BinhluanId = model.BinhLuanChaId,
            Ngaydang = DateTime.Now
        };
        _context.Binhluan.Add(binhLuan);
        _context.SaveChanges();
        return Ok("Save comment successfully");
    }
}