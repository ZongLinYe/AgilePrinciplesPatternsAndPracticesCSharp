using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class GameVersion05
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
        // Version04 -> Version05 : 重構 ScoreForFrame()
        // 重構後依舊不能處理 Spare & Strike 的情況
        //  score += _throws[ball++] + _throws[ball++];
        //  雖然測試沒問題，但我們還是去除這種可能的順序依賴
        public int ScoreForFrame(int theFrame)
        {
            int score = 0;
            int ball = 0;
            for(int currentFrame = 0;
                currentFrame< theFrame;
                currentFrame++)
            {
                //score += _throws[ball++] + _throws[ball++];
                int firstThrow = _throws[ball++];
                int secondThrow = _throws[ball++];

                // 實現 spare
                int frameScore = firstThrow + secondThrow;
                // spare 時需要知道下一輪的第一投
                if (frameScore == 10)
                {
                    //score += frameScore + _throws[ball++];
                    score += frameScore + _throws[ball];
                }
                else
                {
                    score += frameScore;
                }

                //score += firstThrow + secondThrow;
            }
            return score;
        }
    }


}
