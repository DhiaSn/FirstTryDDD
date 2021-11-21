using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PostCarResponse
    {
        public PostCarResponse(FirstTryDDD.Core.AggregateModels.CarAggregate.Car car)
        {
            Id = car.Id;
            Ref = car.Ref;
            Brand = car.Brand;
            CreatedDate = car.CreatedDate; 
        }

        public Guid Id { get; set; }
        public string Ref { get; set; }
        public string Brand { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
