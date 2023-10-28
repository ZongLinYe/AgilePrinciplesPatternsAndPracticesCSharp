/// <remarks>
/// 這個類別產生使用者指定之最大值範圍內的質數
/// 使用的演算法是 Eratosthenes 篩選法
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05
{
    public class GeneratePrimesVersion1
    {
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if(maxValue >= 2)  // 僅在此時有意義
            {
                // 宣告
                int s = maxValue + 1; // 陣列大小
                bool[] f = new bool[s];
                int i;

                // 將陣列元素初始為 true
                for (i = 0; i < s; i++)
                {
                    f[i] = true;
                }

                // 刪除已知的非質數
                f[0] = f[1] = false;
                // sieve 篩選：過濾
                int j;
                for(i=2; i<Math.Sqrt(s) + 1; i++)
                {
                    if (f[i]) // 如果 i 是質數
                    {
                        // 篩選掉 i 的倍數
                        for(j=2*i; j<s; j+=i)
                        {
                            f[j] = false; // i 的倍數不是質數
                        }
                    }
                }
                // 有多少個質數？
                int count = 0;
                for(i=0; i<s; i++)
                {
                    if (f[i])
                    {
                        count++; // 累計質數個數
                    }
                }
                int[] primes = new int[count];
                // 把質數儲存到陣列中
                for(i=0, j=0; i<s; i++)
                {
                    if (f[i]) // 如果是質數
                    {
                        primes[j++] = i;
                    }
                }
                return primes; // 傳回質數陣列

            }
            else // maxValue < 2
            {
                return new int[0]; // 若輸入不合理得值，則傳回空陣列
            }
        }
    }
}
