using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_Strategy_FToC_V1
{
    internal class ApplicationRunner
    {
        private IApplication _application = null;
        public ApplicationRunner(IApplication application)
        {
            _application = application;
        }
        public void Run()
        {
            _application.Init();
            while (_application.IsDone is false)
            {
                _application.Idle();
            }
            _application.Cleanup();
        }
    }
}
