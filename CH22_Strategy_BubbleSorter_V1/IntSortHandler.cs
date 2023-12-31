using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Strategy_BubbleSorter_V1
{
    public class IntSortHandler : ISortHandle
    {
        private int[] _array = null;
        public int Length {
            get {
                return _array.Length;
            } 
        }

        public bool OutOfOrder(int index)
        {
            return (_array[index] > _array[index + 1]);
        }

        public void SetArray(object array)
        {
            _array = (int[])array;
        }

        public void Swap(int index)
        {
            int temp = _array[index];
            _array[index] = _array[index + 1];
            _array[index + 1] = temp;
        }
    }
}
