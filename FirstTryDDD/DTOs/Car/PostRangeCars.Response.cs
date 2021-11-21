using FirstTryDDD.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PostRangeCarsResponse
    {
        public List<PostCarResponse> CreatedCars { get; set; }
        public List<UncreatedCarsResponse> UncreatedCars { get; set; }
    }

    public class UncreatedCarsResponse
    {
        public UncreatedCarsResponse(PostCarRequest car, SimpleErrorResponse response)
        {
            Car = car; 
            Response = response;
        }

        public PostCarRequest Car { get; set; }
        public SimpleErrorResponse Response { get; set; }
    }
}
