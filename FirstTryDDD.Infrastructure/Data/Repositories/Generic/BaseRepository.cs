using FirstTryDDD.Core.Interfaces;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FirstTryDDD.Infrastructure.Data.Repositories.Generic
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region Local Variable + Constructor
        private readonly AppDbContext _dbContext;
        private DbSet<T> _context;

        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;
            _context = _dbContext.Set<T>();
        }
        #endregion

        #region Main Methods

        #region GetAllAsync
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.ToListAsync();
        #endregion

        #region GetByIdAsync
        public async Task<T> GetByIdAsync(Guid id) => await _context.FindAsync(id);
        #endregion

        #region PostAsync
        public async Task<T> PostAsync(T entity)
        {
            DateTime date = DateTime.Now;   
            entity.CreatedDate = date;
            entity.UpdatedDate = date;
            _context.Add(entity);
            await _dbContext.SaveChangesAsync();

            return await GetByIdAsync(entity.Id);
        }
        #endregion

        #region PutAsync
        public async Task<T> PutAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex )
            {
                 
            }

            return await GetByIdAsync(entity.Id);
        }
        #endregion

        #region DeleteAsync
        public async Task DeleteAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
            _context.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #endregion

    }
}
