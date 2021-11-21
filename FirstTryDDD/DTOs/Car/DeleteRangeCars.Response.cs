using FirstTryDDD.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class DeleteRangeCarsResponse
    {
        public List<UnDeletedCarsResponse> UnDeletedCars { get; set; } 
    }
    public class UnDeletedCarsResponse 
    {
        public UnDeletedCarsResponse(DeleteCar car, SimpleErrorResponse response)
        {
            Car = car;
            Response = response;
        }

        public DeleteCar Car { get; set; }  
        public SimpleErrorResponse Response { get; set; }
    }
}
