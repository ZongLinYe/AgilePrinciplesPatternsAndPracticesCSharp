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
    public class FrameVersion02Test
    {
        [TestMethod()]
        public void TestScoreNoThrows()
        {
            // 現在測試案例通過了，但如果向 Frame 物件加入投球的擊倒瓶數，這個測試案例就會失敗
            // 所以我們撰寫這樣的測試案例，他會加入一些投球，然後檢查得分 Version02
            // 現在無法通過編譯，Frame 類別裡面沒有 Add 方法
            FrameVersion02 f = new FrameVersion02();
            f.Add(5);
            Assert.AreEqual(5, f.Score);
            // 我們新增了 Add 方法 & 重新改寫 Score 屬性，測試通過了
            // 但是 Frame.Add 是一個脆弱的方法，如果用 11 作為參數去呼叫他會怎樣呢?
            // 如果發生這種情況，會丟出一個例外。但是誰會去呼叫他呢?
            // 如果我們遇到麻煩，再把這個檢查加進來也不遲
            // 目前 Add 函式還不能處理 strike 和 spare
            // 我們撰寫一個測試案例來說明這種情況 Version03

            


        }
    }
}
