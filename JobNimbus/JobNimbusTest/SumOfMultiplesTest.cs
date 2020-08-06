using JobNimbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JobNimbusTest
{
    [TestClass]
    public class SumOfMultiplesTest
    {
        [TestMethod]
        public void SumTest10()
        {
            long result = SumOfMultiples.Sum(10, new int[] { 3, 5 });

            Assert.AreEqual<long>(23, result);
        }

        [TestMethod]
        public void SumTest100()
        {
            long result = SumOfMultiples.Sum(100, new int[] { 3, 5 });

            Assert.AreEqual<long>(2318, result);
        }


        [TestMethod]
        public void SumTest1000()
        {
            long result = SumOfMultiples.Sum(1000, new int[] { 3, 5 });

            Assert.AreEqual<long>(233168, result);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MultipleContainsZeroTest()
        {
            long result = SumOfMultiples.Sum(1000, new int[] { 0, 5 });
           
        }

        [TestMethod]
        public void TargetNumberZeroTest()
        { 
            long result = SumOfMultiples.Sum(0, new int[] { 3, 5 });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NullMultiplesListTest()
        {
            long result = SumOfMultiples.Sum(1000, null);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EmptyMultiplesListTest()
        {
            long result = SumOfMultiples.Sum(1000, new int[] { });

        }
    }
}
