using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.User
{
    public class PostUserResponse
    {
        public PostUserResponse(FirstTryDDD.Core.AggregateModels.UserAggregate.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
