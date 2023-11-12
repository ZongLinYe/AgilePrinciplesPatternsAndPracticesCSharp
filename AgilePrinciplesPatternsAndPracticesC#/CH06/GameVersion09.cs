using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06
{
    /// <summary>
    /// 重新重構，重構很難...，看到 P88
    /// </summary>
    public class GameVersion09
    {
        //private int _score;
        private int[] _throws = new int[21]; // 一輪有兩次投球機會，共有10輪，最後一輪有可能會投三次
        private int _currentThrow; // 下一個"待"計入分數的位置
        // 新增
        private int _currentFrame = 1;
        private bool _isFirstThrow = true;
        private int _ball ;
        private int _firstThrow;
        private int _secondThrow;

        //public int Score 
        //{          
        //    get { return _score; }
        //}
        public int Score
        {
            get
            {
                return ScoreForFrame(CurrentFrame - 1);
                // 改完之後，TestOneThrow 壞掉了
            }
        }
        // 1.
        //public int CurrentFrame { get { return 1;  } }   
        // 2.
        //public int CurrentFrame { get { return 1+(_currentThrow-1)/2; } }
        // 如果不是每次都去計算他，會怎麼樣呢?
        // 如果每次投球後去調整 _currentFrame 成員變數，會是怎樣呢?
        // 3. 
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
            //_score += pins;
            // 重構，擷取方法
            // 辨認 strike
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (_isFirstThrow)
            {
                // 若是 strike
                // 進入下一輪
                if (pins == 10)
                {
                    _currentFrame++;
                }
                else
                {
                    _isFirstThrow = false;
                }
                //_isFirstThrow = false;

                //_currentFrame++;
            }
            else
            {
                _isFirstThrow = true;
                _currentFrame++;

            }
            // 由於比賽只有 10 輪，當第 10 輪結束時，進入到第 11 輪代表比賽結束
            // ，我們不希望 _currentFrame 超過 11
            // 第 10 輪的第一球是 strike，還可以多丟兩次，第 10 輪的第二球是 strike，第 10 輪的第三球是 strike
            if (_currentFrame > 11)
            {
                _currentFrame = 11;
            }
        }

        public int ScoreForFrame(int theFrame)
        {
            int score = 0;
            //int ball = 0;
            _ball = 0;

            for (int currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {
                _firstThrow = _throws[_ball];
                // 若是第一球是 strike，則第二球不會被投
                if (Strike()) // strike
                {
                    _ball++;
                    // 分數 = 10 + 下一輪的兩球分數
                    score += NextTwoBalls();
                }
                else
                {
                    score += HandleSecondThrow();
                }

            }
            return score;
        }

        private int NextTwoBalls()
        {
            return 10 + _throws[_ball] + _throws[_ball + 1];
        }

        private bool Strike()
        {
            return _firstThrow == 10;
        }

        private int HandleSecondThrow()
        {
            int score = 0;
            _secondThrow = _throws[_ball + 1];

            // 實現 spare
            int frameScore = _firstThrow + _secondThrow;
            // spare 時需要知道下一輪的第一投
            if (Spare())
            {
                _ball += 2;
                score += 10 + NextBall();
            }
            else
            {
                score += TwoBallsInFrame();
                _ball += 2;
            }

            return score;
        }

        private  int TwoBallsInFrame()
        {
            return _throws[_ball]+ _throws[_ball + 1];
        }

        private int NextBall()
        {
            return _throws[_ball];
        }

        private bool Spare()
        {          
            return _throws[_ball] + _throws[_ball + 1] == 10;
        }
    }


}
