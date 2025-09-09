using homepageV2.Common;
using homepageV2.Models;
using homepageV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace homepageV2.Controllers;

[Route("api/Blog")]
public class BlogController(ILogger<BlogController> logger, BlogPostService blogPostService)
    : Controller
{
    private readonly ILogger<BlogController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] int page = 1)
    {
        var posts = await blogPostService.GetPageOfPosts(page);
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
        var postResult = await blogPostService.GetPostByUrl(articleUrl);

        if (postResult.IsSuccess) return new JsonResult(postResult.Value);
        
        if (postResult.Error is NotFoundError)
        {
            return NotFound(postResult.Error);
        }
        return BadRequest(postResult.Error);

    }
    
    [HttpGet("all")]
    public async Task<IActionResult> AllPosts([FromQuery] int page = 1)
    {
        var posts = await blogPostService.GetBlogPosts();
        return new JsonResult(posts);
    }

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> Post(int postId)
    {
        var postResult = await blogPostService.GetPostById(postId);

        if (postResult.IsSuccess) return new JsonResult(postResult.Value);
        
        if (postResult.Error is NotFoundError)
        {
            return NotFound(postResult.Error);
        }
        return BadRequest(postResult.Error);
    }
}