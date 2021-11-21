using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class PostRangeCarsRequest
    {
        public List<PostCarRequest> Cars { get; set; } 
    }
}
