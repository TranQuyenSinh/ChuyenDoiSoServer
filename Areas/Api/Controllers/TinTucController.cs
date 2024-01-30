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
        return new JsonResult(_context.Linhvucs.ToList());
    }

    [HttpGet("tin-tuc")]
    public IActionResult GetTinTucById([FromQuery(Name = "tinTucId")] int tinTucId)
    {
        var tinTuc = _context.Tintucs.Where(x => x.Id == tinTucId)
                            .Include(x => x.IdLinhvucNavigation)
                            .Include(x => x.IdUserNavigation)
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
    public IActionResult GetTinTucByLinhVuc([FromQuery(Name = "linhVucId")] int linhVucId)
    {
        var linhVuc = _context.Linhvucs
                        .Where(x => x.Id == linhVucId)
                        .Include(x => x.Tintucs)
                        .ThenInclude(tin => tin.IdUserNavigation)
                        .Include(x => x.Tintucs)
                        .ThenInclude(tin => tin.IdLinhvucNavigation)
                        .AsSplitQuery()
                        .FirstOrDefault();
        if (linhVuc == null)
            return BadRequest(new
            {
                Code = "linhvuc_not_found",
                Message = "Không tìm thấy lĩnh vực"
            });

        // var tinTucs = linhVuc.TinTucs
        //                 .Where(x => x.TrangThai == 1)
        //                 .OrderByDescending(x => x.CreatedAt)
        //                 .ToList();

        var tinTucs = linhVuc.Tintucs
                        .OrderByDescending(x => x.Ngaydang)
                        .Select(x => new ChiTietTinModel(x))
                        .ToList();

        return new JsonResult(tinTucs);
    }

    [HttpGet("timkiem-tintuc")]
    public IActionResult TimKiemTinTucByTuKhoa([FromQuery(Name = "tuKhoa")] string tuKhoa)
    {
        Console.WriteLine("========== Tìm kiếm tin tức ==========");
        Console.WriteLine("========== Từ khóa: {0} ==========", tuKhoa);
        Console.WriteLine("========== Tìm kiếm tin tức ==========");

        var tinTucs = _context.Tintucs
                        .Include(x => x.IdLinhvucNavigation)
                        .Include(x => x.IdUserNavigation)
                        .Where(x => x.Tieude.Contains(tuKhoa))
                        .Select(x => new ChiTietTinModel(x))
                        .ToList();
        return new JsonResult(tinTucs);
    }
}