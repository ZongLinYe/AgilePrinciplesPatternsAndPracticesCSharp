/// <remarks>
/// 將之前華氏溫度轉換成攝氏溫度的程式，改寫成繼承自 Application 類別的子類別。
/// </remarks>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_V2
{
    public abstract class Application
    {
        // private bool isDone = false;
        protected abstract void Init();
        protected abstract void Idle();
        protected abstract void Cleanup();
        public bool IsDone { get; protected set; }
        // protected void SetDone()
        // {
        //     isDone = true;
        // }
        // public bool Done()
        // {
        //     return isDone;
        // }
        public void Run()
        {
            Init();
            while (IsDone is false)
            {
                Idle();
            }
            Cleanup();
        }
    }
}
