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
    public IActionResult GetBinhLuanByTinTucId([FromQuery(Name = "tinTucId")] int tinTucId)
    {
        Console.WriteLine("======= Lấy bình luận ========");
        var tinTucExist = _context.Tintucs.Any(x => x.Id == tinTucId);

        if (!tinTucExist)
            return BadRequest(new
            {
                Code = "tuctuc_not_found",
                Message = "Không tìm thấy tin tức"
            });


        var binhLuans = _context.Binhluans
                            .Where(x => x.IdTintuc == tinTucId && x.IdBinhluan == null)
                            .Include(x => x.IdUserNavigation)
                            .Include(x => x.InverseIdBinhluanNavigation)
                            .ThenInclude(x => x.IdUserNavigation)
                            .OrderByDescending(x => x.Ngaydang)
                            .Select(x => new BinhLuanModel(x))
                            .ToList();

        return new JsonResult(binhLuans);
    }

    [HttpPost]
    public IActionResult ThemBinhLuan([FromBody] ThemBinhLuanModel model)
    {
        Console.WriteLine("======= Thêm bình luận ========");
        var userExist = _context.Users.Any(x => x.Id == model.UserId);
        var newsExitst = _context.Tintucs.Any(x => x.Id == model.TinTucId);

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
            IdTintuc = model.TinTucId,
            IdUser = model.UserId,
            IdBinhluan = model.BinhLuanChaId,
            Ngaydang = DateTime.Now
        };
        _context.Binhluans.Add(binhLuan);
        _context.SaveChanges();
        return Ok("Save comment successfully");
    }
}