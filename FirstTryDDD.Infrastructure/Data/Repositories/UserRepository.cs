using FirstTryDDD.Core.AggregateModels.UserAggregate;
using FirstTryDDD.Infrastructure.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private DbSet<User> _context;
        public UserRepository(AppDbContext context) : base (context)
        {
            _dbContext = context;
            _context = _dbContext.Set<User>();
        }
    }
}
