using FirstTryDDD.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.CarAggregate
{
    public interface ICarRepository : IGlobalRepository<Car>
    {
    } 
}
