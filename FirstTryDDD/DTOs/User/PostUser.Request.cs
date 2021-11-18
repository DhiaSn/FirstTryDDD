using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.User
{
    public class PostUserRequest 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
