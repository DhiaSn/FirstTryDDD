using FirstTryDDD.Core.Services;
using FirstTryDDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.UserAggregate
{
    public class User : BaseEntity 
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
