/// <remarks>
/// IntBubbleSorter.cs 與 DoubleBubbleSorter.cs 兩個類別，都繼承自 BubbleSorter 類別。
/// 差異在於，IntBubbleSorter.cs 與 DoubleBubbleSorter.cs 兩個類別，各自實作 OutOfOrder() 與 Swap() 方法。
/// 與 array 陣列的型別相關。
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Template_Method_BubbleSorter_V2
{
    internal abstract class BubbleSorter
    {
        private int _operations = 0;
        protected int Length { get; set; } = 0;    
        internal int DoSort()
        {
            _operations = 0;
            if (Length <= 1)
            {
                return _operations;
            }
            for (int nextToLast = Length - 2; nextToLast >= 0; nextToLast--)
            {
                for (int index = 0; index <= nextToLast; index++)
                {
                    if (OutOfOrder(index))
                    {
                        Swap(index);
                    }
                    _operations++;
                }
            }
            return _operations;
        }

        protected abstract bool OutOfOrder(int index);
        protected abstract void Swap(int index);

    }
}
