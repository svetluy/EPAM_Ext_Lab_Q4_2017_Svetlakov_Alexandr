namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DynamicArray<T> : IEnumerable
    {
        const int N = 8;

        private T[] arr;

        public DynamicArray()
        {
            arr = Generate<T>(N);
        }

        public DynamicArray(int capacity)
        {
            arr = Generate<T>(capacity);
        }

        public T this[int index] { get => arr[index]; set => arr[index] = value; }

        public int Capacity => arr.Length;

        public int Length
        {
            get
            {
                int counter = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if(!arr[i].Equals(default(T)))
                    {
                        counter++;
                    }
                }
                return counter;
            }

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

        public void Add(T item)
        {
            ((IList<T>)arr).Add(item);
        }

        public void Clear()
        {
            ((IList<T>)arr).Clear();
        }

        public bool Contains(T item)
        {
            return ((IList<T>)arr).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((IList<T>)arr).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)arr).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)arr).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)arr).Insert(index, item);
        }

        public bool Remove(T item)
        {
            return ((IList<T>)arr).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)arr).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<T>)arr).GetEnumerator();
        }
    }
}
