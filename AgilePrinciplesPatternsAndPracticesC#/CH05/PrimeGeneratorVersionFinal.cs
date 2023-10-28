/// <remarks>
/// 之前我們都在重構程式碼的片段
/// 現在想把這些片段結合在一起是否能成為一個具有可讀性的整體
/// InitializeArrayOfIntegers() 實際上初始化的並不是一個整數陣列，而是一個布林陣列
/// 然而更名為 InitializeArrayOfBooleans 並不會獲得什麼改善
/// 在這個方法中，真正要做的是保留所有相關的整數，以便接下來能夠過濾掉它們的倍數
/// 因此，改為 UncrossIntegersUpto() 會更好
/// isCrossed 作為布林陣列的名字，改為 crossedOut
/// 之前在寫 CalcMaxPrimeFactor() 腦袋糊塗了
/// 陣列長度的平方根未必就是質數
/// 這個方法沒有計算出最大的質因數
/// 說明性的註解完全是錯誤的
/// 所以我改寫了該註解
/// + 1 在那裡究竟有什麼作用呢？肯定是有點偏執了
/// 我擔心具有小數的平方根會轉換為小一點的整數，導致無法充當重複執行的上限
/// 其實這種想法很愚蠢。真正的重複執行上限是小於或等於陣列長度平方根的最大質數，
/// 所以 去掉 + 1
/// 
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersionFinal
    {
        private static bool[] crossedOut;
        private static int[] result;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0]; // 若輸入不合理的值，則傳回空陣列                              

            UncrossIntegersUpto(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();

            return result; // 傳回質數陣列
        }
        /// <summary>
        /// 將沒有被劃掉的整數放進 result 陣列中
        /// </summary>
        private static void PutUncrossedIntegersIntoResult()
        {     
            result = new int[NumberOfUncrossedIntegers()];

            // 把質數儲存到陣列中           
            for (int i = 2, j = 0; i < crossedOut.Length; i++)
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

            for (int i = 2; i < crossedOut.Length; i++)
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
            var limit = DetermineIterationLimit();
            for (int i = 2; i <= limit; i++)
            {
                if (NotCrossed(i)) // 如果未被劃掉，則劃掉其倍數
                {
                    CrossOutputMultiplesOf(i);
                }
            }
        }

        private static bool NotCrossed(int i)
        {
            return crossedOut[i] == false;
        }

        private static int DetermineIterationLimit()
        {
            // 陣列中的每個倍數都有一個小於或等於陣列大小平方根的質因數
            // 因此我們不用劃掉那些比這個平方根還大的數的倍數
            return (int)Math.Sqrt(crossedOut.Length);
        }

        private static void CrossOutputMultiplesOf(int i)
        {
            // 篩選掉 i 的倍數
            for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
            {
                crossedOut[multiple] = true; // i 的倍數不是質數
            }
        }

        private static void UncrossIntegersUpto(int maxValue)
        {
            // 宣告            
            crossedOut = new bool[maxValue + 1];

            for (int i = 2; i < crossedOut.Length; i++)
            {
                crossedOut[i] = false;
            }
        }
    }
}
