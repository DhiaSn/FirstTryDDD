using FirstTryDDD.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.UserAggregate
{
    public interface IUserRepository : IBaseRepository<User> 
    {
    }
}
