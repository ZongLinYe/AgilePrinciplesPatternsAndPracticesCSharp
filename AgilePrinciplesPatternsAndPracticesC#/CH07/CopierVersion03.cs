﻿/// <remarks>
/// First Modified
/// 需求變更，增加紙帶讀取機讀入資料
/// 再次需求變更，希望可以輸出到紙帶穿孔機
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07
{
    public class CopierVersion03
    {
        // 別忘了重新設定這個旗標
        public static bool ptFlag = false;
        public static bool punchFlag = false;
        public static void Copy()
        {
            int c;
            while ((c= ptFlag ? PaperTape.Read() : Keyboard.Read()) != -1)
            {
                if (punchFlag)
                {
                    PaperTape.Punch(c);
                }
                else
                {
                    Printer.Write(c);
                }  
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
        public class PaperTape
        {
            public static int Read()
            {
                return Console.Read();
            }
            public static void Punch(int c)
            {
                Console.Write((char)c);
            }
        }

    }
}
