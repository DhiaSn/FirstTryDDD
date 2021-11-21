using FirstTryDDD.API.DTOs.User;
using FirstTryDDD.Core.AggregateModels.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FirstTryDDD.Core.AggregateModels.CarAggregate;
using FirstTryDDD.API.DTOs.Car;

namespace FirstTryDDD.API.Extentions
{
    public static class ToResponseListExtension
    {
        public static List<L> ToCastedList<T, L>(this IEnumerable<T> list, Func<T, L> enscabulate)
        {            
            List<L> result = new List<L>();
            
            foreach (var item in list)
            {
                result.Add(enscabulate(item));
            }

            return result; 
        }

    }
}
