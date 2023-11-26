using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07.Version01
{
    public class Copier
    {
        public static void Copy()
        {
            int c;
            // 第一版的設計，當鍵盤讀取的數字不等於 -1 時，就指揮列表機印出相應的數字
            while((c = Keyboard.Read()) != -1)
            {
                Printer.Write(c);
            }
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
