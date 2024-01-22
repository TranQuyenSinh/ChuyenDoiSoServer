using ChuyenDoiSoServer.Api.BinhLuan.RequestModel;
using ChuyenDoiSoServer.Api.TinTuc.ResponseModel;
using ChuyenDoiSoServer.Data;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuyenDoiSoServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BinhLuanController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BinhLuanController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBinhLuanByTinTucId([FromQuery(Name = "tinTucId")] int tinTucId)
    {
        Console.WriteLine("======= Lấy bình luận ========");
        var tinTucExist = _context.TinTucs.Any(x => x.Id == tinTucId);

        if (!tinTucExist)
            return BadRequest(new
            {
                Code = "tuctuc_not_found",
                Message = "Không tìm thấy tin tức"
            });


        var binhLuans = _context.BinhLuans
                            .Where(x => x.TinTucId == tinTucId && x.BinhLuanChaId == null)
                            .Include(x => x.User)
                            .Include(x => x.PhanHois)
                            .ThenInclude(x => x.User)
                            .OrderByDescending(x => x.CreatedAt)
                            .Select(x => new BinhLuanModel(x))
                            .ToList();

        return new JsonResult(binhLuans);
    }

    [HttpPost]
    public IActionResult ThemBinhLuan([FromBody] ThemBinhLuanModel model)
    {
        Console.WriteLine("======= Thêm bình luận ========");
        var userExist = _context.Users.Any(x => x.Id == model.UserId);
        var newsExitst = _context.TinTucs.Any(x => x.Id == model.TinTucId);

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

        var binhLuan = new Models.BinhLuan
        {
            NoiDung = model.NoiDung,
            TinTucId = model.TinTucId,
            UserId = model.UserId,
            BinhLuanChaId = model.BinhLuanChaId,
        };
        _context.BinhLuans.Add(binhLuan);
        _context.SaveChanges();
        return Ok("Save comment successfully");
    }
}