using System.Runtime.CompilerServices;

namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
           
        }

        private void RemoveMan<T>(T[] arr) where T : Human
        {
            T[] newArr = new T[arr.Length / 2 + 1];
            for (int i = 0; i < arr.Length; i++)
            {

            }
        }
    }
}
