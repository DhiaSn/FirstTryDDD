using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.User
{
    public class GetUserByIdResponse : FirstTryDDD.Core.AggregateModels.UserAggregate.User
    {
        public GetUserByIdResponse(FirstTryDDD.Core.AggregateModels.UserAggregate.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;
            CreatedDate = user.CreatedDate;
            UpdatedDate = user.UpdatedDate; 
        }
    }
}
