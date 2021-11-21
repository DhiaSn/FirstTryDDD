using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PutCarResponse
    {
        public PutCarResponse(FirstTryDDD.Core.AggregateModels.CarAggregate.Car car)
        {
            Id = car.Id;
            Ref = car.Ref;
            Brand = car.Brand;
            UpdatedDate = car.UpdatedDate;
        }

        public Guid Id { get; set; }
        public string Ref { get; set; }
        public string Brand { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
