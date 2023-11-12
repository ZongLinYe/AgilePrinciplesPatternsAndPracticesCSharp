using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class GameVersion04_2
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
                    // 這裡只試算分數，沒有實際投球，確實不應該 ball++
                    //score += frameScore + _throws[ball++];
                    // 這樣就可以讓 TestSimpleframeAfterSpareV2 通過
                    // 但 TestSimpleFrameAfterSpare 依舊沒通過，因為 Score 有問題，
                    // Score 應該要從 ScoreForFrame() 來取得，而不是 _score
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
