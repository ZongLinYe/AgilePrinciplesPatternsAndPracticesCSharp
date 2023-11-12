using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH06;

namespace AgilePrinciplesPatternsAndPracticesC.CH06.Test
{
    /// <summary>
    /// User Story: 紀錄單一場比賽成績
    /// 比賽開始，有兩位選手
    /// 選手A 開始第一輪第一次投球，擊倒 4 顆瓶
    /// 選手A 開始第一輪第二次投球，擊倒 3 顆瓶
    /// 總共得到 7 分
    /// 選手B 開始第一輪第一次投球，擊倒 5 顆瓶
    /// 選手B 開始第一輪第二次投球，擊倒 4 顆瓶
    /// 總共得到 9 分
    /// 選手A 開始第二輪第一次投球，擊倒 3 顆瓶
    /// 選手A 開始第二輪第二次投球，擊倒 7 顆瓶，是 spare，要等到下一輪才能計算分數
    /// 選手B 開始第二輪第一次投球，擊倒 10 顆瓶，是 strike，要等到下一輪才能計算分數
    /// 選手A 開始第三輪第一次投球，擊倒 4 顆瓶
    /// 選手A 開始第三輪第二次投球，擊倒 2 顆瓶
    /// 計算 選手A 上一輪的得分，第二輪第一次投球擊倒 3 顆瓶，第二輪第二次投球擊倒 7 顆瓶，是 spare，所以第二輪的得分為 10 + 4 = 14 分 加上 第一輪的得分 7 分，總共得到 21 分，第三輪第一次投球擊倒 4 顆瓶，第三輪第二次投球擊倒 2 顆瓶，所以第三輪的得分為 4 + 2 = 6 分，總共得到 27 分  ... 以此類推
    /// 
    /// 
    /// </summary>



    [TestClass()]
    public class GameVersion07Test
    {
        private GameVersion07 _game;

        [TestInitialize]
        public void Setup()
        {
            _game = new GameVersion07();
        }


        //[TestMethod()]
        //public void TestOneThrow()
        //{
        //    // 由於只投一顆球， 第一輪是不完整的，Score 呼叫了 ScoreForFrame(0)
        //    // 這個程式是寫給誰的?誰會去呼叫 Score?
        //    // 假設根本不會在不完整的回合中呼叫該方法，這樣是否合理
        //    // 如果這個測試沒有實際用途，那就刪掉他吧
        //    _game.Add(5);
        //    Assert.AreEqual(5, _game.Score);
        //    // 加入
        //    Assert.AreEqual(1, _game.CurrentFrame);

        //}

        [TestMethod()]
        public void TestTwoThrowsNoMark()
        {
            _game.Add(5);
            _game.Add(4);
            Assert.AreEqual(9, _game.Score);
            // 加入
            //Assert.AreEqual(1, _game.CurrentFrame);
            // 投完兩顆球後，應該會進入到第二局
            Assert.AreEqual(2, _game.CurrentFrame);
        }
        [TestMethod()]
        public void TestFourThrowsNoMark()
        {
            _game.Add(5);
            _game.Add(4);
            _game.Add(7);
            _game.Add(2);
            Assert.AreEqual(18, _game.Score);
            Assert.AreEqual(9, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            // 加入
            //Assert.AreEqual(2, _game.CurrentFrame);
            // 投完第四顆球後，應該是進入到第三局
            Assert.AreEqual(3, _game.CurrentFrame);
            // 失敗
            // 調整 CurrentFrame 屬性，讓他回傳正確的值
        }

        [TestMethod()]
        public void TestSimpleSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            // 加入
            Assert.AreEqual(2, _game.CurrentFrame);
        }

        [TestMethod()]
        public void TestSimpleFrameAfterSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            Assert.AreEqual(18, _game.Score);

            // 加入
            Assert.AreEqual(3, _game.CurrentFrame);
            // 我們回到原先的問題上，要讓 Score 能夠工作
            // 現在可以讓 Score 去呼叫 ScoreForFrame(CurrentFrame -1)了

        }

        [TestMethod()]
        public void TestSimpleFrameAfterSpareV2()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            Assert.AreEqual(3, _game.CurrentFrame);

            // 成功了，Score 有問題，因為 Score 屬性只是 Add 的總和，並不是正確的得分
            // 我們要讓 Score 用現在這一輪作為參數去呼叫 ScoreForFrame() Version06
            // 將這個資訊加入現有的測試 TestOneThrow()
        }
        // 現在來關注關於 Strike 的測試案例
        // 畢竟我們想看到這些 Frame 物件被建構成一個鏈結串列
        [TestMethod()]
        public void TestSimpleStrike()
        {
            _game.Add(10);
            _game.Add(3);
            _game.Add(6);
            Assert.AreEqual(19, _game.ScoreForFrame(1));
            //Assert.AreEqual(28, _game.ScoreForFrame(2));
            Assert.AreEqual(28, _game.Score);
            Assert.AreEqual(3, _game.CurrentFrame);
            // 果不其然失敗了，我們要讓它通過測試
            // 我們修改了 AdjustCurrentFrame() & ScoreForFrame()
            // 通過
            // 我們來寫另一個測試案例，看看能否為滿分比賽
        }

        [TestMethod()]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                _game.Add(10);
            }
            Assert.AreEqual(300, _game.Score);
            Assert.AreEqual(11, _game.CurrentFrame);
            // 通過
            // 現在我們要來處理最後一局的 spare
        }

        [TestMethod()]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Add(0);
                _game.Add(0);
            }
            _game.Add(2);
            _game.Add(8); // 10th frame spare
            _game.Add(10); // Strike in last position of array
            Assert.AreEqual(20, _game.Score);


        }

        [TestMethod()]
        public void TestSampleGame()
        {
            _game.Add(1);
            _game.Add(4);
            _game.Add(4);
            _game.Add(5);
            _game.Add(6);
            _game.Add(4);
            _game.Add(5);
            _game.Add(5);
            _game.Add(10);
            _game.Add(0);
            _game.Add(1);
            _game.Add(7);
            _game.Add(3);
            _game.Add(6);
            _game.Add(4);
            _game.Add(10);
            _game.Add(2);
            _game.Add(8);
            _game.Add(6);
                
            Assert.AreEqual(133, _game.Score);
        }
        [TestMethod()]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            Assert.AreEqual(299, _game.Score);
        }

        [TestMethod()]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
            {
                _game.Add(10);
            }
            _game.Add(9);
            _game.Add(1);
            _game.Add(1);
            Assert.AreEqual(270, _game.Score);
        }

        // 下一步重構

    }
}
