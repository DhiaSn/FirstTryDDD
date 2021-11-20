using FirstTryDDD.Core.Services;
using FirstTryDDD.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Services.AbstractServices
{
    public abstract class GlobalServices : BaseServices
    {
        public abstract Task<Response> GetPaginatedList(int pageNumber, int pageSize);
        public abstract Task<Response> DeleteRangeAsync(IEnumerable<object> entities);
        public abstract Task<Response> PostRangeAsync(IEnumerable<object> entities); 
    }
}
