using FirstTryDDD.API.DTOs;
using FirstTryDDD.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Services.AbstractServices
{
    public abstract class BaseServices
    {
        public abstract Task<Response> GetAllAsync();
        public abstract Task<Response> GetByIdAsync(Guid id);
        public abstract Task<Response> PostAsync(dynamic model);
        public abstract Task<Response> PutAsync(dynamic newModel);
        public abstract Task<Response> DeleteAsync(Guid id); 
    }
}
