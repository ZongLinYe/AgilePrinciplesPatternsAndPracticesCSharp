using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH22_Template_Method_Practice
{
    public abstract class FtoCTemplate
    {
        public bool IsDone { get; protected set; }
        public abstract void Init();
        public abstract void MainFtoCMethod();
        public abstract void EndPrint();
        public void FtoC()
        {
            Init();
            while (!IsDone)
            {
                MainFtoCMethod();
            }
            EndPrint();

        }
    }
}