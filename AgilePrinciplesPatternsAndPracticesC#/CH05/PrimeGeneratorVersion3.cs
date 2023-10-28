/// <remarks>
/// InitializeSieve() 有一些凌亂，所以我對他進行了相當大的整理。
/// 首先把所有使用變數 s 的地方替換為 f.length。
/// 然後，更改了 3 個函式的名字，使它們更具表達力
/// 最後，重新安排了 InitializeArrayOfIntegers (也就是原先的 InitializeSieve) 的內部結構，使他更易於閱讀
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersion3
    {
        private static bool[] f;
        private static int[] result;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];             

            InitializeArrayOfIntegers(maxValue);          
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();

            return result; 
        }
        /// <summary>
        /// 將沒有被劃掉的整數放進 result 陣列中
        /// </summary>
        private static void PutUncrossedIntegersIntoResult()
        {
            // 有多少個質數？

            int count = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i])
                {
                    count++; // 累計質數個數
                }
            }
   
            result = new int[count];

            // 把質數儲存到陣列中
            for (int i = 0, j = 0; i < f.Length; i++)
            {
                if (f[i]) // 如果是質數
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
            for (int i = 2; i < Math.Sqrt(f.Length) + 1; i++)
            {
                if (f[i]) // 如果未被劃掉，則劃掉其倍數
                {
                    // 篩選掉 i 的倍數
                    for (int j = 2 * i; j < f.Length; j += i)
                    {
                        f[j] = false; // i 的倍數不是質數
                    }
                }
            }
        }

        private static void InitializeArrayOfIntegers(int maxValue)
        {
            // 宣告            
            f = new bool[maxValue + 1];

            // 改成不要重新賦值，非質數，也非倍數
            f[0] = f[1] = false;
            // 將f[0], f[1] 以外的陣列元素初始為 true
            for (int i = 2; i < f.Length; i++)
            {
                f[i] = true;
            }
        }

    }
}
