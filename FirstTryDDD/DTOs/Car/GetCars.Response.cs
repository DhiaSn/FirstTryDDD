using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class GetCarsResponse
    {
        public GetCarsResponse(Guid id, string brand, string @ref)
        {
            Id = id;
            Brand = brand;
            Ref = @ref;
        }

        public Guid Id { get; set; }
        public string Ref { get; set; }
        public string Brand { get; set; }
    }
}
