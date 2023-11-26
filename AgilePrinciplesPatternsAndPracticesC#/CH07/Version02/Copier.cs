using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07.Version02
{
    public class Copier
    {
        // 別忘了重新設定這個旗標
        public static bool _ptFlag = false;
        public static void Copy()
        {
            int c;
            // 第二版的設計是 : 當旗標為 true 時，就從紙帶讀取，否則就從鍵盤讀取
            // 這樣的設計，就可以讓程式在執行時，動態的切換讀取的來源
            // 想讓 Copy 從紙帶讀取機中讀入資料的呼叫者，必須先將 _ptFlag 設為 true
            // 一旦 Copy 呼叫返回後，呼叫者必須要重新設定 _ptFlag，否則接下來的呼叫者會錯誤的從紙帶讀取機，而非鍵盤讀入資料
            while((c=(_ptFlag ? PaperTape.Read()
                : Keyboard.Read())) != -1)
            {
                Printer.Write(c);
            }
        }
    }

    internal class PaperTape
    {
        internal static int Read()
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
