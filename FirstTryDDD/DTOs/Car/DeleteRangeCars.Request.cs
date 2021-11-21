using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.Car
{
    public class DeleteRangeCarsRequest
    {
        public List<DeleteCar> Cars { get; set; }
    }
    public class DeleteCar
    {
        public Guid Id { get; set; }
    }
}
