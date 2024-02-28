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
[MyAuthorize(RoleNames = "Admin")]
public class DoanhNghiepController : Controller
{
    private readonly ChuyendoisoContext _context;
    private readonly IEmailSender _emailSender;

    public DoanhNghiepController(ChuyendoisoContext context, IEmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult Index(string search = "", int page = 1)
    {
        var dns = _context.Doanhnghiep
                        .Include(x => x.DoanhnghiepDaidien)
                        .Include(x => x.User)
                        .Include(x => x.DoanhnghiepSdt)
                        .Include(x => x.DoanhnghiepLoaihinh)
                        .AsSplitQuery()
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList();
        if (!string.IsNullOrEmpty(search))
        {
            dns = dns
            .Where(x => x.Tentiengviet.ToLower().Contains(search.ToLower())
             || x.User.Name.ToLower().Contains(search.ToLower()))
            .ToList();

            ViewData["Search"] = search;
        }

        var totalItem = dns.Count;
        dns = dns.Skip((page - 1) * Constants.PAGE_ITEM_COUNT)
                       .Take(Constants.PAGE_ITEM_COUNT)
                       .ToList();
        ViewBag.PagingOptions = new Paging.PagingOptions()
        {
            CurrentPage = page,
            TotalItem = totalItem,
            GenerateUrl = (page) => Url.Action(nameof(Index), new { page, search })
        };
        ViewData["TotalCompany"] = totalItem;
        return View(dns);
    }

    [HttpGet("Detail/{id}")]
    public IActionResult Detail(ulong id)
    {
        var model = _context.Doanhnghiep
                    .Where(x => x.Id == id)
                    .Include(x => x.User)
                    .Include(x => x.DoanhnghiepDaidien)
                    .Include(x => x.DoanhnghiepSdt)
                    .Include(x => x.DoanhnghiepLoaihinh)
                    .ThenInclude(x => x.Linhvuc)
                    .AsSplitQuery()
                    .FirstOrDefault();
        return View(model);
    }

    [HttpPost("gui-mail-xac-thuc")]
    public async Task<IActionResult> GuiEmailXacThuc(ulong id)
    {
        var doanhnghiep = await _context.Doanhnghiep
                            .Where(x => x.Id == id)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();
        if (doanhnghiep == null)
            return BadRequest();

        var verifyToken = Guid.NewGuid().ToString();

        doanhnghiep.User.RememberToken = verifyToken;
        await _context.SaveChangesAsync();

        string subject, body;
        (subject, body) = EmailUtils.TaoMailKichHoat(doanhnghiep.User.Id, verifyToken);
        await _emailSender.SendEmailAsync(doanhnghiep.User.Email, subject, body);

        TempData["StatusMessage"] = "Đã gửi email xác thực";
        return RedirectToAction(nameof(Detail), new { id });
    }

    [HttpPost("duyet-tai-khoan")]
    public async Task<IActionResult> DuyetTaiKhoan(ulong id)
    {
        var doanhnghiep = await _context.Doanhnghiep
                            .Where(x => x.Id == id)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();
        if (doanhnghiep == null)
            return BadRequest();

        doanhnghiep.User.Status = "Active";
        await _context.SaveChangesAsync();

        TempData["StatusMessage"] = "Đã duyệt";
        return RedirectToAction(nameof(Detail), new { id });
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        var doanhnghiep = await _context.Doanhnghiep
                            .Where(x => x.Id == id)
                            .Include(x => x.User)
                            .FirstOrDefaultAsync();
        if (doanhnghiep == null)
            return BadRequest();

        doanhnghiep.User.Status = "Active";
        await _context.SaveChangesAsync();

        TempData["StatusMessage"] = "Đã duyệt";
        return RedirectToAction(nameof(Detail), new { id });
    }

    private SelectList GetListLinhVuc()
    {
        return new SelectList(_context.Linhvuc, "Id", "Tenlinhvuc");
    }
}
