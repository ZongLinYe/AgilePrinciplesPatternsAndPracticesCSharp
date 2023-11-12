using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class GameVersion04
    {
        private int _score ;
        private int[] _throws = new int[21]; // 一輪有兩次投球機會，共有10輪，最後一輪有可能會投三次
        private int _currentThrow ; // 下一個"待"計入分數的位置
        public int Score 
        {          
            get { return _score; }
        }    
        public void Add(int pins)
        {
            _throws[_currentThrow++] = pins;
            _score += pins;
        }

        public int ScoreForFrame(int frame)
        {
            int score = 0;
            for(int ball = 0; // 第幾顆球 (0~21)
                frame>0 && ball < _currentThrow;
                ball+=2,frame--)
            {
                score += _throws[ball] + _throws[ball + 1];
            }
            return score;
        }
    }


}
