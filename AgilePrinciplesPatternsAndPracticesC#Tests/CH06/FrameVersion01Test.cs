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
    public class ThrowTest
    {
        [TestMethod()]
        public void Test()
        {
            // 如果只有紀錄選手的擊倒瓶數，可見他沒做什麼事
            // 也許我們應該重新審視一下，關注具有實際行為的物件，而不僅僅只是儲存資料的物件
            // 也許這個物件不應該存在

        }
    }

    [TestClass()]
    public class FrameVersion01Test
    {
        [TestMethod()]
        public void TestScoreNoThrows()
        {
            FrameVersion01 f = new FrameVersion01();
            Assert.AreEqual(0, f.Score);
            // 現在測試案例通過了，但如果向 Frame 物件加入投球的擊倒瓶數，這個測試案例就會失敗
            // 所以我們撰寫這樣的測試案例，他會加入一些投球，然後檢查得分 Version02


        }
    }
}
