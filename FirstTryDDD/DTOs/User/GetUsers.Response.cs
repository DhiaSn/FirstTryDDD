using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs.User
{
    public class GetUsersResponse 
    {
        public GetUsersResponse(Guid id,string name, int age)
        {
            Id = id; 
            Name = name;
            Age = age;
        }
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
