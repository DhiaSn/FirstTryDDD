using FirstTryDDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.CarAggregate
{
    public class Car : BaseEntity
    {
        public string Ref { get; set; }
        public string Brand { get; set; } 
    }
}
