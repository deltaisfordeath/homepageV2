using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;

namespace HomepageV2.Repos;

public class BlogPostRepository (HomepageContext context)
    : BaseRepository<HomepageContext, BlogPost>(context)
{


    public async Task<BlogPost?> FindByTitle(string title)
    {
        return await DbSet.Where(_ => _.Title == title).FirstOrDefaultAsync();
    }

}