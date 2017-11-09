using System.Collections;

namespace MSTestPlayground
{
    public class LambdaComparer<T> : IComparer
    {
        private readonly CompareFunc<T> _compareFunc;

        public LambdaComparer(CompareFunc<T> compareFunc)
        {
            _compareFunc = compareFunc;
        }
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (!(x is T t1) || !(y is T t2))
            {
                return -1;
            }

            return _compareFunc(t1, t2) ? 0 : 1;
        }
    }
}