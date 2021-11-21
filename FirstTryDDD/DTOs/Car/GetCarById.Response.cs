using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class GetCarByIdResponse : FirstTryDDD.Core.AggregateModels.CarAggregate.Car
    {
        public GetCarByIdResponse(FirstTryDDD.Core.AggregateModels.CarAggregate.Car car)
        {
            Id = car.Id;
            Ref = car.Ref;
            Brand = car.Brand; 
            CreatedDate = car.CreatedDate;
            UpdatedDate = car.UpdatedDate;
        }
    }
}
