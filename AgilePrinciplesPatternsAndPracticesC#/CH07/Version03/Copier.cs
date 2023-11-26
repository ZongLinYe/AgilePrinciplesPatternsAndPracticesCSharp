using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07.Version03
{
    public class Copier
    {
        // 別忘了重新設定這個旗標
        public static bool _ptFlag = false;
        public static bool _punchFlag = false;
        public static void Copy()
        {
            int c;
            // 需求變更，客戶希望 Copy 程式可以輸出到只帶穿孔機上
            // 第三版 
            while ((c = (_ptFlag ? PaperTape.Read()
                : Keyboard.Read())) != -1)
            {              
                // 不懂下面這個寫法會有 error
                //_punchFlag ? PaperTape.Punch(c) : Printer.Write(c);
                if (_punchFlag)
                {
                    PaperTape.Punch(c);
                }else
                {
                    Printer.Write(c);
                }
            }
        }


    }

    internal class PaperTape
    {
        internal static int Read()
        {
            throw new NotImplementedException();
        }
        internal static void Punch(int c)
        {
            throw new NotImplementedException();
        }

    }
    internal class Keyboard
    {
        internal static int Read()
        {
            throw new NotImplementedException();
        }
    }
    internal class Printer
    {
        internal static void Write(int c)
        {
            throw new NotImplementedException();
        }
    }
}
