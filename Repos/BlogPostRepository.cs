using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;

namespace HomepageV2.Repos;

public class BlogPostRepository<TContext, TEntity>(HomepageContext context)
    : BaseRepository<HomepageContext, TEntity>(context)
    where TContext : DbContext
    where TEntity : BlogPost
{


    public async Task<TEntity?> FindByTitle(string title)
    {
        return await DbSet.Where(_ => _.Title == title).FirstOrDefaultAsync();
    }

}