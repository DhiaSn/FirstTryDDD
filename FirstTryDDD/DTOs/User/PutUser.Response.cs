using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.User
{
    public class PutUserResponse
    {
        public PutUserResponse(FirstTryDDD.Core.AggregateModels.UserAggregate.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
            PhoneNumber = user.PhoneNumber;
            UpdatedDate = user.UpdatedDate;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
