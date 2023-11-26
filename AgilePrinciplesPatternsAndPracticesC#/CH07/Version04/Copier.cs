///<remarks>
/// 在這個例子中，敏捷開發人員建構了一個抽象類別，使它們免於因輸入裝置的變化帶來麻煩
/// 它們如何知道要那樣做呢? 這和物件導向設計的一個基本原則有關
/// Copy 程式最初的設計不具有靈活性，是因為其依賴關係的"方向"
/// 一開始 Copy 模組直接依賴 Keyboard.Reader() 和 Printer.Write()
/// 在這個程式中，Copy 模組是一個高層模組。他制定了應用的策略，並知道如何複製字元
/// 糟糕的是，他也依賴於鍵盤和列表機的底層細節。因此，當底層細節發生變化時，高層策略就會受到影響
/// 一旦暴露這種不靈活性，敏捷開發人員就知道，從 Copy 模組到輸入裝置的依賴關係需要按照"依賴反轉原則" (DIP, Dependency Inversion Principle) 進行重構
/// 如此，Copy 模組就不再依賴於鍵盤和列表機，而是依賴於一個抽象的 Reader 介面，以及一個抽象的 Writer 介面
/// 且應用 Strategy 模式來建立想要的反向關係
///</remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH07.Version04
{
    public class Copier
    {
        public static IReader reader;// = new KeyboardReader();
        public Copier(IReader reader)
        {
            // 這裡的 reader 是一個介面，所以可以用來指派不同的物件
            // new KeyboardReader() 或 new PaperTapeReader()
            Copier.reader = reader;
        }
        public static void Copy()
        {
            int c;
            // 敏捷版本，當程式第一次修改時，應該要這樣修改
            // 改進設計，以便對於將來的同類變化具備彈性，而不是設法去給設計補丁
            // 從現在開始，無論老闆何時要求一種新的輸入裝置，團隊都能以不導致 Copy 程式退化的方式做出反應
            // 團隊遵循 OCP(Open-Closed Principle) 原則，開放封閉原則，對於擴展是開放的，對於修改是封閉的
            while ((c = reader.Read()) != -1)
            {
                Printer.Write(c);
            }
        }
    }
    public class Printer
    {
        internal static void Write(int c)
        {
            throw new NotImplementedException();
        }
    }

    public interface IReader
    {
        int Read();
    }
    public class KeyboardReader : IReader
    {
        public int Read()
        {
            return Keyboard.Read();
        }
    }

    public class PaperTapeReader : IReader
    {
        public int Read()
        {
            return PaperTape.Read();
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

}
