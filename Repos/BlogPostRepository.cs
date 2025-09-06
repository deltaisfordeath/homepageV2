using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;
using homepageV2.Data.Models.Generic;

namespace HomepageV2.Repos;

public class BlogPostRepository (HomepageContext context)
    : BaseRepository<HomepageContext, BlogPost>(context)
{

    public async Task<BlogPost?> FindByTitle(string title)
    {
        return await DbSet.Where(_ => _.Title == title).FirstOrDefaultAsync();
    }

    public async Task<BlogPost?> FindByUrl(string url)
    {
        return await DbSet.Where(_ => _.Url == url).FirstOrDefaultAsync();
    }

    public async Task<PaginatedList<BlogPost>> GetPageOfPosts(int pageNum)
    {
        var blogPage = await PaginatedList<BlogPost>.CreateAsync(Context.BlogPosts, pageNum, p => p.CreatedAt);
        return blogPage;
    }

    public async Task<List<BlogPost>> GetAllPosts()
    {
        return await DbSet.ToListAsync();
    }

}