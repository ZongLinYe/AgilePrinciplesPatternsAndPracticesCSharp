/// <remarks>
/// 這是一個 華氏溫度 轉換成 攝氏溫度 的程式，使用者輸入華氏溫度，程式會計算出對應的攝氏溫度。
/// 這個程式使用了一個 while 迴圈，讓使用者可以一直輸入華氏溫度，直到使用者輸入空白行為止。/// 
/// </remarks>

namespace CH22
{
    public class FtoCRaw
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (done is false)
            {
                string fahrString = Console.ReadLine();

                if (string.IsNullOrEmpty(fahrString))
                {
                    done = true;
                }
                else
                {
                    double fahr = double.Parse(fahrString);
                    double celsius = 5.0 / 9.0 * (fahr - 32);
                    Console.WriteLine($"F={fahr}, C={celsius}");
                }
            }
            // dynamic
            // Object

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
