using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLibrary;

namespace TestCalcConsole
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //arrange
            var x = 10.0;
            var y = 1.0;
            var calc = new Calc();

            //act
            var rezult = calc.Sum(x , y);

            //assert
            Assert.AreEqual(rezult, 11);

        }
        
        [TestMethod]
        public void TestSub()
        {
            //arrange
            var x = 10;
            var y = 1;
            var calc = new Calc();

            //act
            var rezult = calc.Sub(x, y);

            //assert
            Assert.AreEqual(rezult, 9);

        }
        [TestMethod]
        public void TestMul()
        {
            //arrange
            var x = 10;
            var y = 2;
            var calc = new Calc();

            //act
            var rezult = calc.Mul(x, y);

            //assert
            Assert.AreEqual(rezult, 20);

        }
        [TestMethod]
        public void TestDiv()
        {
            //arrange
            var x = 10;
            var y = 2;
            var calc = new Calc();

            //act
            var rezult = calc.Div(x, y);

            //assert
            Assert.AreEqual(rezult, 5);

        }
        [TestMethod]
        public void TestDivZero()
        {
            //arrange
            var x = 10.0;
            var y = 0.0;
            var calc = new Calc();

            //act
            var rezult = calc.Div(x, y);

            //assert
            Assert.AreEqual(rezult, Double.NaN);

        }
        [TestMethod]
        public void TestPow()
        {
            //arrange
            var x = 2;
            var y = 3;
            var calc = new Calc();

            //act
            var rezult = calc.Pow(x, y);

            //assert
            Assert.AreEqual(rezult, 8);

        }
        [TestMethod]
        public void TestSqrt()
        {
            //arrange
            var x = 16;
           
            var calc = new Calc();

            //act
            var rezult = calc.Sqrt(x);

            //assert
            Assert.AreEqual(rezult, 4);

        }
    }
}
