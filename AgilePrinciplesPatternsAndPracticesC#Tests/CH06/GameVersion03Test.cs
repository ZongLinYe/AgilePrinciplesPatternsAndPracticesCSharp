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
    public class GameVersion03Test
    {
        [TestMethod()]
        public void TestOneThrow()
        {
            GameVersion03 game = new GameVersion03();
            game.Add(5);
            Assert.AreEqual(5, game.Score);
            // 測試通過了，但仍要尋找需要 Frame 物件的 List 的重要證據，
            // 最初就是它使我們認為需要 Game 物件
            // 一旦加進有關 spare 和 strike 的測試案例，我們就會發現這個 List 是必要的
            // 但是在程式碼迫使我們這樣做之前，暫時我還不想這樣做
            // 我們來撰寫另外一個關於有兩次投球，但沒有 spare 情況的測試 Version04
        }
    }

}
