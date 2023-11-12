using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    public class BowlingGameByMyself
    {
        private int[] _throws = new int[21];
        private int _currentThrow = 0;
        private bool _firstThrow = true;

        //private int 
        public int Score
        {
            get
            {
                return GetScoreForFrame(CurrentFrame-1);
            }
        }
        public int CurrentFrame { get; private set; } = 1;

        public void Add(int pins)
        {
            _throws[_currentThrow++] = pins;
            //Score += pins;
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            //throw new NotImplementedException();
            if (_firstThrow)
            {
                if (pins == 10)
                {
                    CurrentFrame++;
                }
                else
                {
                    _firstThrow = false;
                }
            }
            else
            {
                _firstThrow = true;
                CurrentFrame++;
            }
            if (CurrentFrame > 11)
            {
                CurrentFrame = 11;
            }

        }

        public int GetScoreForFrame(int frame)
        {

            int score = 0;
            int ball = 0;
            for (int currentFrame = 0; currentFrame < frame; currentFrame++)
            {
                if (_throws[ball] == 10)
                {
                    score += 10 + _throws[ball + 1] + _throws[ball + 2];
                    ball++;
                }
                else if (_throws[ball] + _throws[ball + 1] == 10)
                {
                    score += 10 + _throws[ball + 2];
                    ball += 2;
                }
                else
                {
                    score += _throws[ball] + _throws[ball + 1];
                    ball += 2;
                }
            }
            return score;


        }


    }

}
