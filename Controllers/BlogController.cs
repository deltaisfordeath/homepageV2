using homepageV2.Models;
using homepageV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace homepageV2.Controllers;

public class BlogController: Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogPostService _blogPostService;
    
    public static readonly string Name = "Blog";

    public BlogController(ILogger<HomeController> logger, BlogPostService blogPostService)
    {
        _logger = logger;
        _blogPostService = blogPostService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var post = await _blogPostService.GetBlogPost("A New Post");
        var viewModel = new BlogPostViewModel
        {
            Title = post.Title,
            Body = post.Body
        };
        
        return View(viewModel);
    }
}