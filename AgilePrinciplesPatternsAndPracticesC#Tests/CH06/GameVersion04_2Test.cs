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
    public class GameVersion04_2Test
    {
        private GameVersion04_2 _game;
        // MSTestV2 有一個與 NUnit 的 [SetUp] 相對應的特性，稱為 [TestInitialize]。
        // 這個特性可以應用於在每個測試方法執行前需要執行的方法上
        // 在 xUnit 上是用建構子的方式來達成，並實作 IDisposable 介面
        [TestInitialize]
        public void Setup()
        {
            _game = new GameVersion04_2();
        }


        [TestMethod()]
        public void TestOneThrow()
        {
            //GameVersion05 game = new GameVersion05();
            _game.Add(5);
            Assert.AreEqual(5, _game.Score);
        }

        [TestMethod()]
        public void TestTwoThrowsNoMark()
        {
            //GameVersion05 game = new GameVersion05();
            _game.Add(5);
            _game.Add(4);
            Assert.AreEqual(9, _game.Score);
        }
        [TestMethod()]
        public void TestFourThrowsNoMark()
        {
            //GameVersion05 game = new GameVersion05();
            _game.Add(5);
            _game.Add(4);
            _game.Add(7);
            _game.Add(2);
            Assert.AreEqual(18, _game.Score);
            Assert.AreEqual(9, _game.ScoreForFrame(1));
            Assert.AreEqual(18, _game.ScoreForFrame(2));
            // Can work but 程式碼讓人看不懂 (不易了解 Version05
            // 重構 ScoreForFrame 方法，讓他更容易理解 Version05
            // 我們來寫下一個測試案例 spare

        }

        [TestMethod()]
        public void TestSimpleSpare()
        {
            //GameVersion05 game = new GameVersion05();
            // ... 重構測試，把建立 Game 物件實體的步驟放到 Setup 函式中
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            Assert.AreEqual(13, _game.ScoreForFrame(1));
            // 現在測試失敗了，現在我們要讓它通過，加入判斷 spare 的邏輯
            // 通過，但 frameScore == 10 時， score += frameScore + _throws[ball++];
            // 不應該對 ball 遞增，讓我們來寫一個測試案例來驗證 TestSimpleFrameAfterSpare()
        }

        [TestMethod()]
        public void TestSimpleFrameAfterSpare()
        {
            _game.Add(3);
            _game.Add(7);
            _game.Add(3);
            _game.Add(2);
            Assert.AreEqual(13, _game.ScoreForFrame(1));    
            Assert.AreEqual(18, _game.Score);
            // 失敗，果然不能 ball++，修改成 ball 還是失敗
            // Score 錯了嗎? 寫下一個案例
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
            // 成功了，Score 有問題，因為 Score 屬性只是 Add 的總和，並不是正確的得分
            // 我們要讓 Score 用現在這一輪作為參數去呼叫 ScoreForFrame() To Version06
        }


    }

}
