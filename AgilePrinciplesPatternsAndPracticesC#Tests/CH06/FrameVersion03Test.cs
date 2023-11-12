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
    public class FrameVersion03Test
    {
        [TestMethod()]
        public void TestScoreNoThrows()
        {
            // 目前 Add 函式還不能處理 strike 和 spare
            // 我們撰寫一個測試案例來說明這種情況
            // 如果呼叫 Add(10) 來表示一個 strike，那麼 GetScore() 應該回傳什麼呢?
            // 如果呼叫 Add(10) 或者是 呼叫了 Add(3) 後呼叫 Add(7) ，那麼隨後呼叫 GetScore() 是沒有意義的
            // 當前的 Frame 物件必須要根據隨後幾個 Frame 物件實體 (instance) 的得分才能計算自己的得分，
            // 如果後面的 Frame 不存在，那麼他會回傳一些令人討厭的值，例如 -1 或者是 0
            // 我們引入了一個概念，Frame 之間要互相知曉，誰持有這些不同的 Frame 物件實體 (instance) 呢?
            // Game 物件
            // 那麼 Game 依賴於 Frame，而 Frame 也依賴於 Game，這樣的循環依賴是不好的
            // Frames 不必依賴於 Game，可把它放置在一個 List，每個 Frame 都有指向他之前及之後 Frame 的指標
            FrameVersion03 f = new FrameVersion03();
            f.Add(5);
            Assert.AreEqual(5, f.Score);
        }
    }
}
