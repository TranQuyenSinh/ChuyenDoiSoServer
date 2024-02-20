using ChuyenDoiSoServer.Api.TinTuc.ResponseModel;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuyenDoiSoServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TinTucController : ControllerBase
{
    private readonly ChuyendoisoContext _context;

    public TinTucController(ChuyendoisoContext context)
    {
        _context = context;
    }

    [HttpGet("linh-vuc")]
    public IActionResult GetLinhVuc()
    {
        return new JsonResult(_context.Linhvuc.ToList());
    }

    [HttpGet("tin-tuc")]
    public IActionResult GetTinTucById([FromQuery(Name = "tinTucId")] ulong tinTucId)
    {
        var tinTuc = _context.Tintuc.Where(x => x.Id == tinTucId)
                            .Include(x => x.Linhvuc)
                            .Include(x => x.User)
                            .FirstOrDefault();
        if (tinTuc == null)
            return BadRequest(new
            {
                Code = "tintuc_not_found",
                Message = "Không tìm thấy tin"
            });

        var model = new ChiTietTinModel(tinTuc);
        return new JsonResult(model);
    }

    [HttpGet("tintuc-by-linhvuc")]
    public IActionResult GetTinTucByLinhVuc([FromQuery(Name = "linhVucId")] string linhVucId)
    {
        var linhVuc = _context.Linhvuc
                        .Where(x => x.Id == linhVucId)
                        .Include(x => x.Tintuc)
                        .ThenInclude(tin => tin.User)
                        .Include(x => x.Tintuc)
                        .ThenInclude(tin => tin.Linhvuc)
                        .AsSplitQuery()
                        .FirstOrDefault();
        if (linhVuc == null)
            return BadRequest(new
            {
                Code = "linhvuc_not_found",
                Message = "Không tìm thấy lĩnh vực"
            });

        var tinTucs = linhVuc.Tintuc
                        .OrderByDescending(x => x.CreatedAt)
                        .Select(x => new ChiTietTinModel(x))
                        .ToList();

        return new JsonResult(tinTucs);
    }

    [HttpGet("timkiem-tintuc")]
    public IActionResult TimKiemTinTucByTuKhoa([FromQuery(Name = "tuKhoa")] string tuKhoa)
    {
        var tinTucs = _context.Tintuc
                        .Include(x => x.Linhvuc)
                        .Include(x => x.User)
                        .Where(x => x.Tieude.Contains(tuKhoa))
                        .Select(x => new ChiTietTinModel(x))
                        .ToList();
        return new JsonResult(tinTucs);
    }
}