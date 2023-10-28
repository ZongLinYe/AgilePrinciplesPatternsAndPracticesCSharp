using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace AgilePrinciplesPatternsAndPracticesC_.CH04.Tests
{
    [TestClass()]
    public class WupusGameTests
    {
        /// <summary>
        /// User Story:  
        /// 透過 "東面的通道" 把 "房間 4" 連接到 "房間 5"，
        /// 把玩家放置在 "房間 4" 中，
        /// 發出了向東移動的命令，
        /// 接著 Assert 玩家應該在 "房間 5" 當中
        /// </summary>
        [TestMethod()]
        public void TestMove()
        {
            WupusGame game = new WupusGame();
            game.Connect(4, 5, "E");
            game.GetPlayerRoom(4);
            game.East();
            Assert.AreEqual(5, game.GetPlayerRoom());
    
        }

        //[TestMethod()]
        //public void TestPayroll()
        //{
        //    var db = Substitute.For<IModckEmployeeDatabase>();
        //    var w = Substitute.For<IMockCheckWriter>();

        //    var p = new Payroll(db, w);
        //    p.PayEmployees();
            
        //}
    }
}