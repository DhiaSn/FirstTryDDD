using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PutCarRequest
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Ref { get; set; }
    }
}
