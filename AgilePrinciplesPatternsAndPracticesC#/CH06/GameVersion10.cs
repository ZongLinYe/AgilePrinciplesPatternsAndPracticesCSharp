///<remarks>
/// 再重構 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class GameVersion10
    {     
        private int[] _throws = new int[21]; // 一輪有兩次投球機會，共有10輪，最後一輪有可能會投三次
        private int _currentThrow; // 下一個"待"計入分數的位置
        // 新增
        private int _currentFrame = 1;
        private bool _isFirstThrow = true;
        private int _ball ;
    
        public int Score
        {
            get
            {
                return ScoreForFrame(CurrentFrame - 1);         
            }
        }       
        public int CurrentFrame
        {
            get
            {
                return _currentFrame;
            }
        }


        public void Add(int pins)
        {
            _throws[_currentThrow++] = pins;
        
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (_isFirstThrow)
            {               
                if (pins == 10)
                {
                    _currentFrame++;
                }
                else
                {
                    _isFirstThrow = false;
                }             
            }
            else
            {
                _isFirstThrow = true;
                _currentFrame++;

            }

            if (_currentFrame > 11)
            {
                _currentFrame = 11;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int score = 0;        
            _ball = 0;
            /// <remarks>
            /// 改成
            /// if strike
            ///     score += 10 + 下兩球的分數
            /// else if spare
            ///     score += 10 + 下一球的分數
            /// else
            ///     score += 本輪兩球的分數
            /// </remarks>
            for (int currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {             
                // 若是第一球是 strike，則第二球不會被投
                if (Strike()) // strike
                {
                    score += NextTwoBallsForStrike();
                    _ball++;           
                }
                else if(Spare())
                {
                    // _ball 是本輪第一球的位置, _ball + 1 是本輪第二球的位置 = 10
                    // _ball + 2 是下一輪第一球的位置
                    score += 10 + NextBallForSpare();
                    _ball += 2;
                }
                else 
                {
                    //score += HandleSecondThrow();
                    // _ball 是本輪第一球的位置, _ball + 1 是本輪第二球的位置 = 10
                    // _ball + 2 是下一輪第一球的位置
                    // 所以這裡不可以先  _ball += 2;
                    score += TwoBallsInFrame();
                    _ball += 2;
                }

            }
            return score;
        }

        private int NextTwoBallsForStrike()
        {
            return 10 + _throws[_ball+1] + _throws[_ball + 2];
        }

        private bool Strike()
        {
            return _throws[_ball] == 10;
        }

        //private int HandleSecondThrow()
        //{
        //    int score = 0;
    
        //    if (Spare())
        //    {
        //        _ball += 2;
        //        score += 10 + NextBall();
        //    }
        //    else
        //    {
        //        score += TwoBallsInFrame();
        //        _ball += 2;
        //    }

        //    return score;
        //}

        private  int TwoBallsInFrame()
        {
            return _throws[_ball]+ _throws[_ball + 1];
        }

        private int NextBallForSpare()
        {
            return _throws[_ball+2];
        }

        private bool Spare()
        {          
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }
    }


}
