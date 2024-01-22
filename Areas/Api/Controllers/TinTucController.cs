using ChuyenDoiSoServer.Api.TinTuc.ResponseModel;
using ChuyenDoiSoServer.Data;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChuyenDoiSoServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TinTucController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TinTucController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("linh-vuc")]
    public IActionResult GetLinhVuc()
    {
        return new JsonResult(_context.LinhVucs.ToList());
    }

    [HttpGet("tin-tuc")]
    public IActionResult GetTinTucById([FromQuery(Name = "tinTucId")] int tinTucId)
    {
        var tinTuc = _context.TinTucs.Find(tinTucId);
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
        var linhVuc = _context.LinhVucs
                        .Where(x => x.Id == linhVucId)
                        .Include(x => x.TinTucs).FirstOrDefault();
        if (linhVuc == null)
            return BadRequest(new
            {
                Code = "linhvuc_not_found",
                Message = "Không tìm thấy lĩnh vực"
            });

        // var tinTucs = linhVuc.TinTucs
        //                 .Where(x => x.TrangThai == 1)
        //                 .OrderBy(x => x.CreatedAt)
        //                 .ToList();

        var tinTucs = linhVuc.TinTucs
                        .OrderBy(x => x.CreatedAt)
                        .Select(x => new ChiTietTinModel(x))
                        .ToList();

        return new JsonResult(tinTucs);
    }


}