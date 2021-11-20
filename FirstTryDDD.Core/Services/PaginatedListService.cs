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
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage { get { return (PageNumber > 1); } }
        public bool HasNextPage { get { return (PageNumber < TotalPages); } }

        public PaginatedListService(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageNumber = pageIndex;
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
        public static PaginatedListService<T> Create(IQueryable<T> list, int count, int pageNumber, int pageSize) => new PaginatedListService<T>(list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), count, pageNumber, pageSize);

    }
}
