using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.SharedKarnel.Extensions
{
    public static class CollectionExtensions
    {
        #region ToCastedList
        public static List<L> ToCastedList<T, L>(this IEnumerable<T> list, Func<T, L> enscabulate)
        {
            List<L> result = new List<L>();

            foreach (var item in list)
            {
                result.Add(enscabulate(item));
            }

            return result;
        }
        public static async Task<List<L>> ToCastedList<T, L>(this IEnumerable<T> list, Func<T, Task<L>> enscabulate)
        {
            List<L> result = new List<L>();

            foreach (var item in list)
            {
                result.Add(await enscabulate(item));
            }

            return result;
        }
        #endregion
    }
}
