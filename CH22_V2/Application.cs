using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_V2
{
    public abstract class Application
    {
        private bool isDone = false;
        protected abstract void Init();
        protected abstract void Idle();
        protected abstract void Cleanup();
        protected void SetDone()
        {
            isDone = true;
        }
        public bool Done()
        {
            return isDone;
        }
        public void Run()
        {
            Init();
            while (Done() is false)
            {
                Idle();
            }
            Cleanup();
        }
    }
}
