using HomepageV2.Data;
using HomepageV2.Data.Models;
using HomepageV2.Repos;

namespace homepageV2.Services;

public class BlogPostService(BlogPostRepository blogPostRepository)
{
    public async Task<BlogPost> GetBlogPost(string title)
    {
        var post = await blogPostRepository.FindByTitle(title);
        return post ?? new BlogPost();
    }
}