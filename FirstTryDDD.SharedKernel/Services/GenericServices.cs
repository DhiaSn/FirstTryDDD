using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.SharedKernel.Services
{
    public static class GenericServices<T>
    {
        public static bool IsDefaultValue(dynamic value) => EqualityComparer<T>.Default.Equals(value, default(T)); 
    }
}
