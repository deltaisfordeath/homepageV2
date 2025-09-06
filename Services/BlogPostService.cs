using HomepageV2.Data.Models;
using homepageV2.Data.Models.Generic;
using HomepageV2.Repos;

namespace homepageV2.Services;

public class BlogPostService(BlogPostRepository blogPostRepository)
{
    public async Task<BlogPost> GetPostByTitle(string title)
    {
        var post = await blogPostRepository.FindByTitle(title);
        return post;
    }

    public async Task<BlogPost> GetPostByUrl(string url)
    {
        var post = await blogPostRepository.FindByUrl(url);
        return post;
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

    public async Task<BlogPost> GetPostById(int postId)
    {
        var post = await blogPostRepository.FindById(postId);
        return post;
    }
}