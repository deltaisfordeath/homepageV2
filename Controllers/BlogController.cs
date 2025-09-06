using homepageV2.Models;
using homepageV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace homepageV2.Controllers;

[Route("api/Blog")]
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
        return new JsonResult(new
        {
            posts = posts.Items, 
            hasNextPage = posts.HasNextPage, 
            hasPreviousPage = posts.HasPreviousPage,
            pageIndex = posts.PageIndex
        });
    }

    [HttpGet("{articleUrl}")]
    public async Task<IActionResult> BlogPost(string articleUrl)
    {
        var post = await _blogPostService.GetPostByUrl(articleUrl);
        return new JsonResult(post);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> AllPosts([FromQuery] int page = 1)
    {
        var posts = await _blogPostService.GetBlogPosts();
        return new JsonResult(posts);
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