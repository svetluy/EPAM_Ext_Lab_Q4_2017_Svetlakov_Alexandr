namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DynamicArray<T> : IEnumerable<T>
    {
        private const int N = 8;
        private const int Multiplier = 2;

        private T[] arr;

        public DynamicArray() : this(N)
        {
        }

        public DynamicArray(int capacity)
        {
            this.arr = Generate<T>(capacity);
            this.Length = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            this.arr = Generate<T>(enumerable.Count() + N);
            enumerable.CopyTo(this.arr, 0);
            this.Length = enumerable.Count();
        }

        public int Capacity => this.arr.Length;

        public int Length { get; private set; }

        public T this[int index]
        {
            get => this.arr[index];
            set
            {
                if (index < this.Length && index > 0)
                {
                    this.arr[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            if (this.Length < this.Capacity)
            {
                this.Length++;
                this.arr[this.Length] = item;
            }
            else
            {
                this.arr = Generate<T>(this.Capacity * Multiplier);
                this.Length++;
                this.arr[this.Length] = item;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            if (this.Capacity < this.Length + enumerable.Length)
            {
                enumerable.CopyTo(this.arr, this.Length);
                this.Length += enumerable.Length;
            }
            else
            {
                var tmpArr = new T[this.Length];
                this.arr.CopyTo(tmpArr, 0);
                this.arr = Generate<T>(enumerable.Length + this.Length);
                tmpArr.CopyTo(this.arr, 0);
                enumerable.CopyTo(this.arr, this.Length);
                this.Length = tmpArr.Length + enumerable.Length;
            }
        }

        public void Insert(int index, T item)
        {
            if (index < this.Length && index > 0)
            {
                var b = new T[this.Length + 1];
                Array.Copy(this.arr, 0, b, 0, index - 1);
                b[index] = item;
                Array.Copy(this.arr, index, b, index + 1, this.Length - index - 1);
                if (this.Length < this.Capacity)
                {
                    this.arr = Generate<T>(this.Capacity);
                    b.CopyTo(this.arr, 0);
                    this.Length = b.Length;
                }
                else
                {
                    this.arr = Generate<T>(this.Capacity * Multiplier);
                    b.CopyTo(this.arr, 0);
                    this.Length = b.Length;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Remove(T item)
        {
            if (!this.arr.Contains(item))
            {
                return false;
            }
            else
            {
                this.arr = this.arr.Where(item1 => !item1.Equals(item)).ToArray();
                this.Length--;
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.arr.GetEnumerator();
        }

        private A[] Generate<A>(int n)
        {
            A[] arr = new A[n];
            this.Length = 0;
            return arr;
        }
    }
}
