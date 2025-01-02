using System.Diagnostics;
using HomepageV2.Data.Models;
using Microsoft.AspNetCore.Mvc;
using homepageV2.Models;
using homepageV2.Services;

namespace homepageV2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogPostService _blogPostService;

    public HomeController(ILogger<HomeController> logger, BlogPostService blogPostService)
    {
        _logger = logger;
        _blogPostService = blogPostService;
    }

    public IActionResult Index()
    {
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
