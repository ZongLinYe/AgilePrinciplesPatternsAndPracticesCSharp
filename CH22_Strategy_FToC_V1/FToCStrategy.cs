using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Strategy_FToC_V1
{
    internal class FToCStrategy : IApplication
    {

        public bool IsDone { get; private set; }

        public void Cleanup()
        {
            Console.WriteLine("FToC Exit");
        }

        public void Idle()
        {
            // 華氏轉換成攝氏溫度，請 KeyIn 華氏溫度
            Console.WriteLine("華氏轉換成攝氏溫度，請 KeyIn 華氏溫度");
            string fahrenheit = Console.ReadLine();
            // 請確認是否正確轉換 double
            if (double.TryParse(fahrenheit, out double f))
            {
                // 計算攝氏溫度
                double celsius = (f - 32) * (5.0 / 9.0);
                // 輸出攝氏溫度
                Console.WriteLine($"攝氏溫度為 {celsius}");
            }
            else
            {
                // 輸入錯誤
                Console.WriteLine("輸入錯誤");
                IsDone = true;
            }

        }

        public void Init()
        {
            IsDone = false;
        }

      
    }
}
