using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Template_Method_BubbleSorter_V2
{
    internal class IntBubbleSorter : BubbleSorter
    {
        private int[] array = null;

        public int Sort(int[] theArray)
        {
            array = theArray;
            Length = array.Length;
            return DoSort();
        }
        protected override bool OutOfOrder(int index)
        {
            return (array[index] > array[index + 1]);
        }

        protected override void Swap(int index)
        {
            int temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }
    }
}
