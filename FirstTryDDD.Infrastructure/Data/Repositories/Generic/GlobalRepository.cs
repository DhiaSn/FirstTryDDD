using FirstTryDDD.Core.Interfaces;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstTryDDD.Infrastructure.Data.Repositories.Generic
{
    public class GlobalRepository<T> : BaseRepository<T>, IGlobalRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _context;
        public GlobalRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
            _context = _dbContext.Set<T>();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PostRangeAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedDate = DateTime.Now;
                _context.Add(item);
            }
            await _dbContext.SaveChangesAsync();

        }
    }
}
