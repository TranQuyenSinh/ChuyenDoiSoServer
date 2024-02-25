using ChuyenDoiSoServer.Admin.Models;
using ChuyenDoiSoServer.Models;
using ChuyenDoiSoServer.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChuyenDoiSoServer.Admin.Controllers;

[Route("admin")]
[Area("Admin")]
public class HomeController : AuthorizeController
{
    private readonly ChuyendoisoContext _context;
    public HomeController(ChuyendoisoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
