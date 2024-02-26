using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChuyenDoiSoServer.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChuyenDoiSoServer.Admin.TinTuc.RequestModels;
using ChuyenDoiSoServer.Components;

namespace ChuyenDoiSoServer.Admin.Controllers;

[Route("Admin/[controller]")]
[Area("Admin")]
[MyAuthorize(RoleNames = "Cộng tác viên")]
public class TinTucController : Controller
{
    private readonly ChuyendoisoContext _context;
    public TinTucController(ChuyendoisoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index(string search = "", int page = 1)
    {
        var tinTucs = _context.Tintuc
                        .Include(x => x.User)
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList();
        if (!string.IsNullOrEmpty(search))
        {
            tinTucs = tinTucs
            .Where(x => x.Tieude.ToLower().Contains(search.ToLower())
             || x.User.Name.ToLower().Contains(search.ToLower()))
            .ToList();

            ViewData["Search"] = search;
        }

        var totalItem = tinTucs.Count;
        tinTucs = tinTucs.Skip((page - 1) * Constants.PAGE_ITEM_COUNT)
                       .Take(Constants.PAGE_ITEM_COUNT)
                       .ToList();
        ViewBag.PagingOptions = new Paging.PagingOptions()
        {
            CurrentPage = page,
            TotalItem = totalItem,
            GenerateUrl = (page) => Url.Action(nameof(Index), new { page, search })
        };
        return View(tinTucs);
    }

    [HttpGet("Create")]
    public IActionResult Create()
    {
        ViewData["LinhVucId"] = GetListLinhVuc();
        return View();
    }

    [HttpPost("Create"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTinTuc model, IFormFile File)
    {
        var userId = UserUtils.GetUserId(HttpContext.Session);
        if (ModelState.IsValid && userId != 0)
        {

            var tinTuc = new Tintuc()
            {
                Tieude = model.Tieude,
                Tomtat = model.Tomtat,
                Noidung = model.Noidung,
                LinhvucId = model.LinhvucId,
                UserId = userId.Value,
                Hinhanh = CommonUtils.UploadImage(CommonUtils.TIN_TUC_PHOTO, File),
                Luotxem = 0,
                Duyet = 0
            };
            _context.Tintuc.Add(tinTuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        };
        ViewData["LinhVucId"] = GetListLinhVuc();
        return View(model);
    }

    [HttpPut]
    public async Task<IActionResult> DuyetTin(ulong id, sbyte isDuyet)
    {
        var tin = await _context.Tintuc.FindAsync(id);
        if (tin == null)
            return BadRequest();
        tin.Duyet = isDuyet;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(ulong id)
    {
        var model = _context.Tintuc
                            .Where(x => x.Id == id)
                            .Select(x => new EditTinTuc(x))
                            .FirstOrDefault();

        ViewData["LinhVucId"] = GetListLinhVuc();
        return View(model);
    }

    [HttpPost("Edit/{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditTinTuc model, IFormFile? File)
    {
        if (ModelState.IsValid)
        {
            var tinTuc = await _context.Tintuc.FirstOrDefaultAsync(x => x.Id == model.Id);
            tinTuc.Tieude = model.Tieude;
            tinTuc.Tomtat = model.Tomtat;
            tinTuc.Noidung = model.Noidung;
            tinTuc.LinhvucId = model.LinhvucId;

            if (File != null)
            {
                CommonUtils.DeleteImage(CommonUtils.TIN_TUC_PHOTO, tinTuc.Hinhanh);
                tinTuc.Hinhanh = CommonUtils.UploadImage(CommonUtils.TIN_TUC_PHOTO, File);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        };
        ViewData["LinhVucId"] = GetListLinhVuc();
        return View(model);
    }

    [HttpGet("Delete/{id}")]
    public IActionResult Delete(ulong id)
    {
        var model = _context.Tintuc
                    .Where(x => x.Id == id)
                    .Include(x => x.User)
                    .Select(x => new DeleteTinTuc(x))
                    .FirstOrDefault();
        return View(model);
    }

    [HttpPost("Delete/{id}", Name = "DeleteTinTuc"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAsync(ulong id)
    {
        var model = await _context.Tintuc.FindAsync(id);
        _context.Remove(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("Detail/{id}")]
    public IActionResult Detail(ulong id)
    {
        var model = _context.Tintuc
                    .Where(x => x.Id == id)
                    .Include(x => x.User)
                    .FirstOrDefault();
        return View(model);
    }


    private SelectList GetListLinhVuc()
    {
        return new SelectList(_context.Linhvuc, "Id", "Tenlinhvuc");
    }
}
