using homepageV2.Models;
using homepageV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace homepageV2.Controllers;

[Route("Blog")]
public class BlogController: Controller
{
    private readonly ILogger<BlogController> _logger;
    private readonly BlogPostService _blogPostService;

    public const string Name = "Blog";

    public BlogController(ILogger<BlogController> logger, BlogPostService blogPostService)
    {
        _logger = logger;
        _blogPostService = blogPostService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] int page = 1)
    {
        var posts = await _blogPostService.GetPageOfPosts(page);
        var viewModel = new BlogIndexViewModel
        {
            Items = posts.Items,
            HasNextPage = posts.HasNextPage
        };
        
        return View(viewModel);
    }

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> Post(int postId)
    {
        var post = await _blogPostService.GetPostById(postId);
        var viewModel = new BlogPostViewModel
        {
            Title = post.Title,
            Body = post.Body,
            ViewCount = post.ViewCount
        };
        return View(viewModel);
    }
}