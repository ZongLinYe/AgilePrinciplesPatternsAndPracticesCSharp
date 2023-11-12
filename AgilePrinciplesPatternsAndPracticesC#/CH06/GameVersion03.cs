using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class GameVersion03
    {
        private int _score ;
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
