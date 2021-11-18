using FirstTryDDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> PostAsync(T entity);
        Task<T> PutAsync(T entity);
        Task DeleteAsync(Guid id);

    }
}
