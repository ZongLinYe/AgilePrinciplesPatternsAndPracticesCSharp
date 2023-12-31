using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Strategy_BubbleSorter_V1
{
    public class BubbleSorter
    {
        private int _operations = 0;
        private ISortHandle _sortHandle = null;
        public BubbleSorter(ISortHandle sortHandle)
        {
            _sortHandle = sortHandle;
        }

    }
}
