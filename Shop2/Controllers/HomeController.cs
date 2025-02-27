using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var s = "1";
        var i = s.ToInt();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public static class NumberUtility
{
    public static int ToInt(this string s)
    {
        return int.Parse(s);
    }
}