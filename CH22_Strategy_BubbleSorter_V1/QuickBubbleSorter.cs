using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Strategy_BubbleSorter_V1
{
    internal class QuickBubbleSorter 
    {
        private int _operations = 0;
        private ISortHandle _sortHandle = null;
        public QuickBubbleSorter(ISortHandle sortHandle)
        {
            _sortHandle = sortHandle;
        }

        public int Sort(object array)
        {
            _sortHandle.SetArray(array);
            _operations = 0;
            if (_sortHandle.Length <= 1)
            {
                return _operations;
            }
            bool thisPassInOrder = false;
            for (int nextToLast = _sortHandle.Length - 2; nextToLast >= 0 && !thisPassInOrder; nextToLast--)
            {
                thisPassInOrder = true;
                for (int index = 0; index <= nextToLast; index++)
                {
                    if (_sortHandle.OutOfOrder(index))
                    {
                        _sortHandle.Swap(index);
                        thisPassInOrder = false;
                    }
                    _operations++;
                }
            }
            return _operations;
        }
       
    }
}
