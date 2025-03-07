using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace homepageV2.Data.Models.Generic
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        
        public List<T> Items { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync<TKey>(IQueryable<T> source, int pageIndex, Expression<Func<T, TKey>> orderBy, int pageSize = 10)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(orderBy).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
    
}

