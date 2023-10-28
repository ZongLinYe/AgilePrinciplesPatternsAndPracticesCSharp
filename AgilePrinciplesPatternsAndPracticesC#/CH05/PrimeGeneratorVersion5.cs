/// <remarks>
/// 重構 PutUncrossedIntegersIntoResult() 方法
/// 這個方法分為兩個功能
/// 第一個部分計算陣列中沒有被過濾掉的整數數量，並建立一個同樣大小的陣列，來存放這些結果
/// 第二個部分是把那些沒有被過濾掉的整數搬移到結果陣列中。
/// 我們把第一個部分的功能提取出來，並做一些清理工作
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersion5
    {

        private static bool[] isCrossed;
        private static int[] result;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0]; // 若輸入不合理的值，則傳回空陣列                              

            InitializeArrayOfIntegers(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();

            return result; // 傳回質數陣列
        }
        /// <summary>
        /// 將沒有被劃掉的整數放進 result 陣列中
        /// </summary>
        private static void PutUncrossedIntegersIntoResult()
        {
            // 有多少個質數？
            int count = NumberOfUncrossedIntegers();

            result = new int[count];

            // 把質數儲存到陣列中           
            for (int i = 2, j = 0; i < isCrossed.Length; i++)
            {
                if (NotCrossed(i)) // 如果是質數
                {
                    result[j++] = i;
                }
            }
        }

        private static int NumberOfUncrossedIntegers()
        {
            int count = 0;

            for (int i = 2; i < isCrossed.Length; i++)
            {
                if (NotCrossed(i))
                {
                    count++; // 累計質數個數
                }
            }

            return count;
        }

        /// <summary>
        /// 劃掉其倍數
        /// </summary>
        private static void CrossOutMultiples()
        {
            var maxPrimeFactor = CalcMaxPrimeFactor();
            for (int i = 2; i < maxPrimeFactor + 1; i++)
            {
                if (NotCrossed(i)) // 如果未被劃掉，則劃掉其倍數
                {
                    CrossOutputMultiplesOf(i);
                }
            }
        }

        private static bool NotCrossed(int i)
        {
            return isCrossed[i] == false;
        }

        private static int CalcMaxPrimeFactor()
        {
            // 我們劃掉質數 p 的所有倍數
            // 那麼被劃掉的所有倍數都有 p 和 q 兩個因數
            // 如果 p 大於陣列大小的平方根，那麼 q 就不能再大於 1 了
            // 因此 p 就是陣列中最大的質因數，也就是所需反覆執行次數的上限
            return (int)Math.Sqrt(isCrossed.Length);
        }

        private static void CrossOutputMultiplesOf(int i)
        {
            // 篩選掉 i 的倍數
            for (int multiple = 2 * i; multiple < isCrossed.Length; multiple += i)
            {
                isCrossed[multiple] = true; // i 的倍數不是質數
            }
        }

        private static void InitializeArrayOfIntegers(int maxValue)
        {
            // 宣告            
            isCrossed = new bool[maxValue + 1];

            for (int i = 2; i < isCrossed.Length; i++)
            {
                isCrossed[i] = false;
            }
        }

    }
}
