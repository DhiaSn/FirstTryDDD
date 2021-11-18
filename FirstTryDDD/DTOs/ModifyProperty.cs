using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTryDDD.API.DTOs
{
    public class ModifyProperty
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public object PropertyValue { get; set; }
    }
}
