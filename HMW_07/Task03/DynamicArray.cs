namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DynamicArray<T> 
    {
        private T[] arr;

        public DynamicArray()
        {
            arr = Generate<T>(8);
        }

        public DynamicArray(int length)
        {
            arr = new T[length];
        }

        public DynamicArray(T)
        {
            arr = new T[length];
        }

        static T[] Generate<T>(int n)
        {
            T[] arr = new T[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = default(T);
            }
            return arr;
        }
    }
}
