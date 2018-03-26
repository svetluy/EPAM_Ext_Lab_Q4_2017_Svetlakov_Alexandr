namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DynamicArray<T> : IEnumerable<T> // todo pn круто, а тесты на все методы?) лучше отдельным классом
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

        public int Capacity { get; private set; }

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
            if (this.Length + 1 < this.Capacity)
            {
                this.arr[this.Length] = item;
                this.Length++;
            }
            else
            {
                var tmp = this.Length;
                this.NextSize(this);
                this.arr[tmp] = item;
                this.Length++;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            if (this.Capacity > this.Length + enumerable.Count())
            {
                enumerable.CopyTo(this.arr, this.Length);
                this.Length += enumerable.Count();
            }
            else
            {
                var tmpArr = new T[this.Capacity];
                var tmp = this.Length;
                this.arr.CopyTo(tmpArr, 0);
                this.arr = Generate<T>(enumerable.Count() + this.Length + N);
                tmpArr.CopyTo(this.arr, 0);
                enumerable.CopyTo(this.arr, tmp);
                this.Length = this.arr.Length;
            }
        }

        public bool Insert(int index, T item)
        {
            if (index <= this.Length && index >= 0)
            {
                if (this.Length + 1 > this.Capacity)
                {
                    this.NextSize(this);
                }

                this.ShiftArr(index);
                this.arr[index] = item;
                return true;
            }
            else
            {
                return false;
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Remove(T item)
        {
            int index = this.FindIndex(this.arr, item);
            if (!this.arr.Contains(item) || (index >= this.Length))
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
            this.Capacity = n;
            return arr;
        }

        private int FindIndex(T[] arr, T item)
        {
            int index = -1;
            arr.First(n => { index++; return n.Equals(item); });
            return index;
        }

        private void ShiftArr(int index)
        {
            for (int i = this.Length; i > index; i--)
            {
                this.arr[i] = this.arr[i - 1];
            }

            this.Length += 1;
        }

        private void NextSize(DynamicArray<T> sourceArray)
        {
            var tmpArr = new T[sourceArray.Capacity];
            Array.Copy(sourceArray.arr, tmpArr, sourceArray.arr.Length);
            sourceArray.arr = Generate<T>(sourceArray.Capacity * Multiplier);
            Array.Copy(tmpArr, sourceArray.arr, tmpArr.Length);
            sourceArray.Length = tmpArr.Length - 1;
        }
    }
}
