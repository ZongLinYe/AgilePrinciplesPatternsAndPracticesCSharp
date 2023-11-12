﻿///<remarks>
/// 再重構 
/// </remarks>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    /// <summary>
    /// Game 只管 輪
    /// </summary>
    public class GameVersion13
    {
        private int _currentFrame = 1;
        private bool _isFirstThrow = true;
        private ScorerVersion13 scorer = new ScorerVersion13();
    
        public int Score
        {
            get
            {               
                return ScoreForFrame(_currentFrame);
            }
        }

        public int ScoreForFrame(int theFrame)
        {     
            return scorer.ScoreForFrame(theFrame);
        }

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            //if (_isFirstThrow)
            //{
            //    if (AdjustFrameForStrike(pins) == false)
            //    {                  
            //        _isFirstThrow = false;
            //    }               
            //}
            //else
            //{
            //    _isFirstThrow = true;
            //    AdvanceFrame();
            //}

            // Why? 看不太懂...
            if((_isFirstThrow && pins == 10) || (!_isFirstThrow))
            {
                AdvanceFrame();
            }
            else
            {
                _isFirstThrow = false;
            }
        }

        //private bool AdjustFrameForStrike(int pins)
        //{
        //    if(pins == 10)
        //    {
        //        AdvanceFrame();
        //        return true;
        //    }

        //    return false;
        //}

        private void AdvanceFrame()
        {
            _currentFrame++;        
            if (_currentFrame > 10)
            {
                _currentFrame = 10;
            }
        }
    }
    /// <summary>
    /// Scorer 只計算分數
    /// </summary>
    public class ScorerVersion13
    {
        private int _ball;
        private int[] _throws = new int[21]; // 一輪有兩次投球機會，共有10輪，最後一輪有可能會投三次
        private int _currentThrow; // 下一個"待"計入分數的位置


        private int TwoBallsInFrame()
        {
            return _throws[_ball] + _throws[_ball + 1];
        }

        private int NextBallForSpare()
        {
            return _throws[_ball + 2];
        }

        private bool Spare()
        {
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }
        private int NextTwoBallsForStrike()
        {
            return 10 + _throws[_ball + 1] + _throws[_ball + 2];
        }

        private bool Strike()
        {
            return _throws[_ball] == 10;
        }

      

        public int ScoreForFrame(int theFrame)
        {
            int score = 0;
            _ball = 0;
        
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
                else if (Spare())
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

        internal void AddThrow(int pins)
        {            
            _throws[_currentThrow++] = pins;
        }
    }
}
