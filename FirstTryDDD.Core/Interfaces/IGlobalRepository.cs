using FirstTryDDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.Interfaces
{
    public interface IGlobalRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        Task PostRangeAsync(IEnumerable<T> entities);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
