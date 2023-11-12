using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH06.Tests
{
    [TestClass()]
    public class BowlingGameByMyselfTests
    {
        private BowlingGameByMyself _game;
        [TestInitialize]
        public void Setup()
        {
            _game = new BowlingGameByMyself();
        }

        //[TestMethod()]
        //public void Add_投一顆球有五個球瓶倒地_得到五分()
        //{
        //    //Assert.Fail();
        //    _game.Add(5);
        //    Assert.AreEqual(5, _game.Score);
        //}

        [TestMethod()]
        public void Add_共投兩顆球第一顆球五個球瓶倒地第二顆球三個球瓶倒地_共得八分()
        {
            //Assert.Fail();
            _game.Add(5);
            _game.Add(3);
            Assert.AreEqual(8, _game.Score);
        }
        //[TestMethod()]
        //public void Add_共投三顆球第一顆球五個球瓶倒地第二顆球一樣五個球瓶倒地Spare第三顆球三個球瓶倒地_共得十六分()
        //{
        //    //Assert.Fail();
        //    _game.Add(5);
        //    _game.Add(5);
        //    _game.Add(3);
        //    Assert.AreEqual(16, _game.Score);
        //}

        [TestMethod()]
        public void Add_共投四顆球第一顆球4個球瓶倒地第二顆球一樣五個球瓶倒地Spare第三顆球三個球瓶倒地第四顆球三個球瓶倒地_共得15分()
        {
            //Assert.Fail();
            _game.Add(4);
            _game.Add(5);
            _game.Add(3);
            _game.Add(3);
            Assert.AreEqual(15, _game.Score);
            Assert.AreEqual(9,_game.GetScoreForFrame(1));
            Assert.AreEqual(15, _game.GetScoreForFrame(2));
        }
        //[TestMethod()]
        //public void Add_共投四顆球第一顆球五個球瓶倒地第二顆球一樣五個球瓶倒地Spare第三顆球三個球瓶倒地第四顆球三個球瓶倒地_共得十九分()
        //{
        //    //Assert.Fail();
        //    _game.Add(5);
        //    _game.Add(5);
        //    _game.Add(3);
        //    _game.Add(3);
        //    Assert.AreEqual(19, _game.Score);
        //}
        //[TestMethod()]
        //public void Add_共投四顆球第一顆球五個球瓶倒地第二顆球一樣五個球瓶倒地Spare第三顆球三個球瓶倒地第四顆球7個球瓶倒地Spare第五顆球4個球瓶倒地_共得31分()
        //{
        //    //Assert.Fail();
        //    _game.Add(5);
        //    _game.Add(5);
        //    _game.Add(3);
        //    _game.Add(7);
        //    _game.Add(4);
        //    Assert.AreEqual(31, _game.Score);
        //}


        //[TestMethod()]
        //public void Add_共投四顆球第一顆球十個球瓶倒地Strike第二顆球三個球瓶倒地第三顆球三個球瓶倒地_共得二十二分()
        //{
        //    //Assert.Fail();
        //    _game.Add(10);
        //    _game.Add(3);
        //    _game.Add(3);
        //    Assert.AreEqual(22, _game.Score);
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
            Assert.AreEqual(9, _game.GetScoreForFrame(1));
            Assert.AreEqual(18, _game.GetScoreForFrame(2));
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
            Assert.AreEqual(13, _game.GetScoreForFrame(1));
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
            Assert.AreEqual(13, _game.GetScoreForFrame(1));
            Assert.AreEqual(18, _game.GetScoreForFrame(2));
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
            Assert.AreEqual(13, _game.GetScoreForFrame(1));
            Assert.AreEqual(18, _game.GetScoreForFrame(2));
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
            Assert.AreEqual(19, _game.GetScoreForFrame(1));
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
    }
}