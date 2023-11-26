/// <remarks>
/// First Modified
/// 需求變更，增加紙帶讀取機讀入資料 版本2
/// 再次需求變更，希望可以輸出到紙帶穿孔機 版本3
/// ---------
/// 敏捷設計 版本2
/// </remarks>
/// <remarks>
/// 從鍵盤讀入字元並輸出到列表機的程式
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07
{

    public interface IReader
    {
        int Read();
    }


    public class CopierVersion04
    {
        public static IReader reader = new KeyboardReader();
        public static void Copy()
        {
            
            int c;
            while ((c = reader.Read()) != -1)
            {
                Printer.Write(c);
            }
        }

        public class Keyboard
        {
            public static int Read()
            {
                return Console.Read();
            }
        }

        public class Printer
        {
            public static void Write(int c)
            {
                Console.Write((char)c);
            }
        }

        public class KeyboardReader : IReader
        {
            public int Read()
            {
                return Keyboard.Read();
            }
        }



    }
}
