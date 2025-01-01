using HomepageV2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HomepageV2.Data
{
    public class HomepageContext(DbContextOptions<HomepageContext> contextOptions): DbContext(contextOptions)
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}