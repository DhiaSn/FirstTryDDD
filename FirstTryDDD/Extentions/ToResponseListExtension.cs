using FirstTryDDD.API.DTOs.User;
using FirstTryDDD.Core.AggregateModels.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FirstTryDDD.API.Extentions
{
    public static class ToResponseListExtension
    { 
        public static List<GetUsersResponse> ToResponseList(this IEnumerable<User> list)
        {
            List<GetUsersResponse> result = new List<GetUsersResponse>();

            foreach (var item in list)
            {
                result.Add(new GetUsersResponse(item.Id, item.Name, item.Age)); 
            }

            return result; 
        }
    }
}
