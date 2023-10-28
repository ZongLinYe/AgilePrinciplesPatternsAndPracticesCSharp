/// <remarks>
/// 在 CrossOoutMultiples() 方法和其他一些方法中有許多像是 if(f[i] == true ) 的語句。
/// 這條語句的意圖是檢查 i 是否為質數，是質數的為 true，不是質數的為 false。
/// 所以我們把 f 重新命名為 unCrossed[i]
/// 但這樣改名後會產生 unCrossed[i] = false 這種令人困惑的語句。
/// 所以我們在把它改成 isCrossed[i] = true 。
/// 改成這樣的話之前存 true 的位置，會變成存 false。更改所有布林值的含意 
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersion4_1
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
            for (int i = 0; i < isCrossed.Length; i++)
            {
                // 根據語意變更布林值
                if (isCrossed[i]==false)
                {
                    count++; // 累計質數個數
                }
            }
     
            result = new int[count];

            // 把質數儲存到陣列中
            for (int i = 0, j = 0; i < isCrossed.Length; i++)
            {
                // 根據語意變更布林值
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
                // 根據語意變更布林值
                if (isCrossed[i]==false) 
                {
                    // 篩選掉 i 的倍數
                    for (int j = 2 * i; j < isCrossed.Length; j += i)
                    {
                        // 根據語意變更布林值
                        isCrossed[j] = true; // i 的倍數不是質數
                    }
                }
            }
        }

        private static void InitializeArrayOfIntegers(int maxValue)
        {
            // 宣告            
            isCrossed = new bool[maxValue + 1];

            // 根據語意變更布林值
            isCrossed[0] = isCrossed[1] = true;
    
            for (int i = 2; i < isCrossed.Length; i++)
            {
                // 根據語意變更布林值
                isCrossed[i] = false;
            }
        }
    }
}
