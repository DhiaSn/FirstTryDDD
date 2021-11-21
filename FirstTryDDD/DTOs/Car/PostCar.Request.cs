using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PostCarRequest
    {
        public string Ref { get; set; }
        public string Brand { get; set; }
    }
}
