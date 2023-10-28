using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciplesPatternsAndPracticesC_.CH05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPatternsAndPracticesC_.CH05.Tests
{
    [TestClass()]
    public class PrimeGeneratorVersionFinalTests
    {
        [TestMethod()]
        public void GeneratePrimeNumbersTest()
        {
            int[] nullArray = PrimeGeneratorVersionFinal.GeneratePrimeNumbers(0);
            Assert.AreEqual(0, nullArray.Length);

            int[] minArray = PrimeGeneratorVersionFinal.GeneratePrimeNumbers(2);
            Assert.AreEqual(1, minArray.Length);
            Assert.AreEqual(2, minArray[0]);

            int[] threeArray = PrimeGeneratorVersionFinal.GeneratePrimeNumbers(3);
            Assert.AreEqual(2, threeArray.Length);
            Assert.AreEqual(2, threeArray[0]);
            Assert.AreEqual(3, threeArray[1]);

            int[] centArray = PrimeGeneratorVersionFinal.GeneratePrimeNumbers(100);
            Assert.AreEqual(25, centArray.Length);
            Assert.AreEqual(97, centArray[24]);
        }

        [TestMethod()]
        public void TestExhaustive()
        {
            for(int i =2; i < 500; i++)
            {
                VerifyPrimeList(PrimeGeneratorVersionFinal.GeneratePrimeNumbers(i));
            }        
        }

        private void VerifyPrimeList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                VerifyPrime(list[i]);
            }
        }

        private void VerifyPrime(int v)
        {
            for(int factor = 2; factor < v; factor++)
            {
                Assert.IsTrue(v % factor != 0);
            }
        }
    }
}