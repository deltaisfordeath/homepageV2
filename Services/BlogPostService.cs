using homepageV2.Common;
using HomepageV2.Data.Models;
using homepageV2.Data.Models.Generic;
using HomepageV2.Repos;

namespace homepageV2.Services;

public class BlogPostService(BlogPostRepository blogPostRepository)
{
    public async Task<Result<BlogPost>> GetPostByTitle(string title)
    {
        var post = await blogPostRepository.FindByTitle(title);
        if (post is null)
        {
            return Result<BlogPost>.Failure(
                new NotFoundError("BlogPost.NotFound", $"Blog post with title'{title}' was not found.")
            );
        }
        
        return Result<BlogPost>.Success(post);
    }

    public async Task<Result<BlogPost>> GetPostByUrl(string url)
    {
        var post = await blogPostRepository.FindByUrl(url);
        
        if (post is null)
        {
            return Result<BlogPost>.Failure(
                new NotFoundError("BlogPost.NotFound", $"Blog post with URL '{url}' was not found.")
            );
        }
        
        return Result<BlogPost>.Success(post);
    }

    public async Task<PaginatedList<BlogPost>> GetPageOfPosts(int pageNum)
    {
        var postList = await blogPostRepository.GetPageOfPosts(pageNum);
        return postList;
    }

    public async Task<List<BlogPost>> GetBlogPosts()
    {
        var posts = await blogPostRepository.GetAllPosts();
        return posts;
    }

    public async Task<Result<BlogPost>> GetPostById(int postId)
    {
        var post = await blogPostRepository.FindById(postId);
        if (post is null)
        {
            return Result<BlogPost>.Failure(
                new NotFoundError("BlogPost.NotFound", $"Blog post with ID '{postId}' was not found.")
            );
        }
        
        return Result<BlogPost>.Success(post);
    }
}