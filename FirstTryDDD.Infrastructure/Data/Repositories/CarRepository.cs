using FirstTryDDD.Core.AggregateModels.CarAggregate;
using FirstTryDDD.Infrastructure.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Infrastructure.Data.Repositories
{
    public class CarRepository : GlobalRepository<Car>, ICarRepository
    {
        private readonly AppDbContext _dbContext;
        private DbSet<Car> _context; 
        public CarRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
            _context = _dbContext.Set<Car>(); 
        }
    }
}
