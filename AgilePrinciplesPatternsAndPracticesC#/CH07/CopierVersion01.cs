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
    public class CopierVersion01
    {
        public static void Copy()
        {
            int c;
            while ((c=Keyboard.Read()) != -1)
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

    }
}
