using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH04.Tests
{
    [TestClass()]
    public class WupusGameTests
    {
        [TestMethod()]
        public void TestMove()
        {
            WupusGame game = new WupusGame();
            game.Connect(1, 2, "N");
            game.GetPlayerRoom(4);
            game.East();
            Assert.AreEqual(2, game.GetPlayerRoom());
    
        }      
    }
}