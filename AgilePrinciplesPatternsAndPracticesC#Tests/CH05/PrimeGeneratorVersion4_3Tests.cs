﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05.Tests
{
    [TestClass()]
    public class PrimeGeneratorVersion4_3Tests
    {
        [TestMethod()]
        public void GeneratePrimeNumbersTest()
        {
            int[] nullArray = PrimeGeneratorVersion4_3.GeneratePrimeNumbers(0);
            Assert.AreEqual(0, nullArray.Length);

            int[] minArray = PrimeGeneratorVersion4_3.GeneratePrimeNumbers(2);
            Assert.AreEqual(1, minArray.Length);
            Assert.AreEqual(2, minArray[0]);

            int[] threeArray = PrimeGeneratorVersion4_3.GeneratePrimeNumbers(3);
            Assert.AreEqual(2, threeArray.Length);
            Assert.AreEqual(2, threeArray[0]);
            Assert.AreEqual(3, threeArray[1]);

            int[] centArray = PrimeGeneratorVersion4_3.GeneratePrimeNumbers(100);
            Assert.AreEqual(25, centArray.Length);
            Assert.AreEqual(97, centArray[24]);
        }
    }
}