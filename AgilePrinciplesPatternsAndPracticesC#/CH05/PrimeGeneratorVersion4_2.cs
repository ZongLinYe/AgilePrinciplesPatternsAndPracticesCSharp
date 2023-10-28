/// <remarks>
/// 我們省略設定 isCrossed[0] & isCrossed[1] 為 true 的初始化程式碼
/// 並確保在所有地方都不會使用小於 2 的索引來存取 isCrossed 陣列 
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersion4_2
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
            int count = 0;
            // 略過 isCrossed[0] & isCrossed[1]，所以更改 for loop 的起始值
            for (int i = 2; i < isCrossed.Length; i++)
            {
                if (isCrossed[i] == false)
                {
                    count++; // 累計質數個數
                }
            }
         
            result = new int[count];

            // 把質數儲存到陣列中
            // 略過 isCrossed[0] & isCrossed[1]，所以更改 for loop 的起始值
            for (int i = 2, j = 0; i < isCrossed.Length; i++)
            {
                if (isCrossed[i] == false) // 如果是質數
                {
                    result[j++] = i;
                }
            }
        }
        /// <summary>
        /// 劃掉其倍數
        /// </summary>
        private static void CrossOutMultiples()
        {
            for (int i = 2; i < Math.Sqrt(isCrossed.Length) + 1; i++)
            {
                if (isCrossed[i] == false) // 如果未被劃掉，則劃掉其倍數
                {
                    // 篩選掉 i 的倍數
                    for (int j = 2 * i; j < isCrossed.Length; j += i)
                    {
                        isCrossed[j] = true; // i 的倍數不是質數
                    }
                }
            }
        }

        private static void InitializeArrayOfIntegers(int maxValue)
        {
            // 宣告            
            isCrossed = new bool[maxValue + 1];

            //// 略過 isCrossed[0] & isCrossed[1]
            //isCrossed[0] = isCrossed[1] = true;

            for (int i = 2; i < isCrossed.Length; i++)
            {
                isCrossed[i] = false;
            }
        }

    }
}
