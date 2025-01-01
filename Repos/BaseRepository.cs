using HomepageV2.Data.Models;
using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;


namespace HomepageV2.Repos;

public class BaseRepository<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class
{
    protected readonly TContext Context;

    private DbSet<TEntity> _dbSet;

    protected BaseRepository(TContext context)
    {
        Context = context;
        _dbSet = Context.Set<TEntity>();
    }

    protected DbSet<TEntity> DbSet
    {
        get
        {
            return _dbSet ??= Context.Set<TEntity>();
        }
    }

    public async Task<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        return await DbSet.AddAsync(entity);
    }

    public async Task<TEntity?> FindById(int id)
    {
        return await DbSet.FindAsync(id);
    }
}