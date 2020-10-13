using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sandbox
{
    public static class ExtentionLinq
    {
        public static IEnumerable<List<T>> SplitList<T>(this IEnumerable<T> locations, int nSize )
        {
            List<T> list = locations.ToList();
            for (int i = 0; i < list.Count; i += nSize)
            {
                yield return list.GetRange(i, Math.Min(nSize, list.Count - i));
            }
        }
    }
}
