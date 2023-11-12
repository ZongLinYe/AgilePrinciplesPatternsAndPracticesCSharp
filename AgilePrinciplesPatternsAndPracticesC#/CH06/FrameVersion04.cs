using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class FrameVersion04
    {
        private int _score = 0;
        public int Score
        {
            get { return _score; }
        }

        public void Add(int pins)
        {
            _score += pins;
        }
    }



}
