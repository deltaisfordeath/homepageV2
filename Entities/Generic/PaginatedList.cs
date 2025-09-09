using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace homepageV2.Data.Models.Generic
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
            HasPreviousPage = pageIndex > 1;
            HasNextPage = PageIndex < TotalPages;
        }

        public static async Task<PaginatedList<TEntity>> CreateAsync<TEntity, TKey>(
            IQueryable<TEntity> source,
            int pageIndex, 
            Expression<Func<TEntity, TKey>> orderBy, 
            int pageSize = 10) where TEntity : class
        {
            var count = await source.CountAsync();
            var items = await source.OrderBy(orderBy)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var list = new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
            return list;
        }
    }
    
}

