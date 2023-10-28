/// <remarks>
/// 主函式被分為三個獨立的函式。
/// 第一個函式會對所有的變數進行初始化動作，並做好過濾所需的準備工作
/// 第二個函式執行過濾工作
/// 第三個函式則是把過濾結果存放到一個整數陣列中
/// 對這三個函式的提取迫使我把該函式的一些區域變數提升為類別的靜態欄位 (static field)
/// 這更清楚顯示出哪些是區域變數，哪些是全域變數
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class PrimeGeneratorVersion2
    {
        private static int s;
        private static bool[] f;
        private static int[] primes;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
                return new int[0]; // 若輸入不合理的值，則傳回空陣列                              

            InitializeSieve(maxValue);
            // sieve 篩選：過濾     
            Sieve();
            LoadPrimes();

            return primes; // 傳回質數陣列
        }
        /// <summary>
        /// 計算範圍內有幾個質數
        /// </summary>
        private static void LoadPrimes()
        {
            // 有多少個質數？
        
            int count = 0;
            for (int i = 0; i < s; i++)
            {
                if (f[i])
                {
                    count++; // 累計質數個數
                }
            }
            // 下面這樣寫雖然沒有報錯，但當離開 LoadPrimes() 方法時，primes 陣列就會被釋放掉
            // private static int[] primes; 會變 null
            // int[] primes = new int[count];
            primes = new int[count];

            // 把質數儲存到陣列中
            for (int i = 0, j = 0; i < s; i++)
            {
                if (f[i]) // 如果是質數
                {
                    primes[j++] = i;
                }
            }
        }
        /// <summary>
        /// 篩選
        /// </summary>
        private static void Sieve()
        {
            for (int i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i]) // 如果未被劃掉，則劃掉其倍數
                {
                    // 篩選掉 i 的倍數
                    for (int j = 2 * i; j < s; j += i)
                    {
                        f[j] = false; // i 的倍數不是質數
                    }
                }
            }
        }
        /// <summary>
        /// 篩選前的初始化
        /// </summary>
        /// <param name="maxValue"></param>
        private static void InitializeSieve(int maxValue)
        {
            // 宣告
            s = maxValue + 1; // 陣列大小
            f = new bool[s];

            // 將陣列元素初始為 true
            for (int i = 0; i < s; i++)
            {
                f[i] = true;
            }
            // 刪除已知的非質數
            f[0] = f[1] = false;
        }
    }
}
