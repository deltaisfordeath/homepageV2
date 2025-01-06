using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;
using homepageV2.Data.Models.Generic;

namespace HomepageV2.Repos;

public class BlogPostRepository (HomepageContext context)
    : BaseRepository<HomepageContext, BlogPost>(context)
{
    private readonly HomepageContext _context = context;

    public async Task<BlogPost?> FindByTitle(string title)
    {
        return await DbSet.Where(_ => _.Title == title).FirstOrDefaultAsync();
    }

    public async Task<BlogPost?> FindById(int Id)
    {
        return await DbSet.Where(_ => _.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<PaginatedList<PaginatedObject>> GetPageOfPosts(int pageNum)
    {
        return await PaginatedList<PaginatedObject>.CreateAsync(_context.BlogPosts, pageNum, p => p.CreatedAt);
    }

    public async Task<List<BlogPost>> GetAllPosts()
    {
        return await DbSet.ToListAsync();
    }

}