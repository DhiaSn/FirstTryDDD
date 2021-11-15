using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.Services
{
    /// <summary>
    /// Generic paginator list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedListService<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage { get { return (PageIndex > 1); } }
        public bool HasNextPage { get { return (PageIndex < TotalPages); } }

        public PaginatedListService(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        /// <summary>
        /// This method is the responsible to create a PaginatedList
        /// </summary>
        /// <param name="source">list.AsNoTracking()</param>
        /// <param name="pageIndex">pageNumber ?? 1</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns></returns>
        public static async Task<PaginatedListService<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedListService<T>(items, count, pageIndex, pageSize);
        }
    }
}
