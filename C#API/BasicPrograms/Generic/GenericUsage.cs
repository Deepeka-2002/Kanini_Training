using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class GenericUsage<T> where T:Exception
    {
        /*

        private T[] arr;

        public GenericUsage(int size)
        {
            arr = new T[size];
        }
        
        public T getarr(int index)
        { 
            return arr[index];

        }
        public void setarr(int index, T value)
        {
            arr[index] = value;
        }
        */

        /*
        private T number;

        public GenericUsage(T number)
        {
            this.number = number;
        }

        public T Number { get => number; set => number = value; }
        */
    }
}
